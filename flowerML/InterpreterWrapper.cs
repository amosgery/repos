
using Android.Content.Res;
using Android.Graphics;
using Java.IO;
using Java.Nio.Channels;
using Java.Nio;
using Xamarin.TensorFlow.Lite;


namespace flowerML
{
    public class InterpreterWrapper
    {
        private Interpreter interpreter;
        private string[] labels;
        private int inputSize = 28;

        public InterpreterWrapper(AssetManager assets)
        {
            var model = LoadModelFile(assets, "notes_model.tflite");
            interpreter = new Interpreter(model);

            using (var stream = assets.Open("notes_labels.txt"))
            using (var reader = new StreamReader(stream))
            {
                labels = reader.ReadToEnd()
                               .Split('\n')
                               .Where(l => !string.IsNullOrWhiteSpace(l))
                               .ToArray();
            }
        }

        private static MappedByteBuffer LoadModelFile(AssetManager assets, string path)
        {
            var fileDescriptor = assets.OpenFd(path);
            var inputStream = new FileInputStream(fileDescriptor.FileDescriptor);
            var fileChannel = inputStream.Channel;
            return fileChannel.Map(FileChannel.MapMode.ReadOnly, fileDescriptor.StartOffset, fileDescriptor.DeclaredLength);
        }

        ByteBuffer CreateInputBuffer(Bitmap bitmap, int width, int height)
        {
            Bitmap scaled = Bitmap.CreateScaledBitmap(bitmap, width, height, true);
            ByteBuffer buffer = ByteBuffer.AllocateDirect(width * height * 4); // 3 channels * 4 bytes (float32)
            buffer.Order(ByteOrder.NativeOrder());

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int pixel = scaled.GetPixel(x, y);

                    // Extract RGB and normalize to [0, 1]
                    float r = ((pixel >> 16) & 0xFF) / 255f;
                    float g = ((pixel >> 8) & 0xFF) / 255f;
                    float b = (pixel & 0xFF) / 255f;

                    //buffer.PutFloat(r);
                    //buffer.PutFloat(g);
                    buffer.PutFloat(b);
                }
            }

            buffer.Rewind();
            return buffer;
        }

        public (string label, float confidence) Classify(Bitmap bitmap)
        {
         
            ByteBuffer input = CreateInputBuffer(bitmap, inputSize, inputSize);
            // Allocate output buffer (flat)
            float[] results = RunModel(input);

            // Post-processing: find highest score
            int maxIdx = 0;
            float maxVal = results[0];

            for (int i = 1; i < results.Length; i++)
            {
                if (results[i] > maxVal)
                {
                    maxVal = results[i];
                    maxIdx = i;
                }
            }

            string predictedLabel = labels[maxIdx];

            return (labels[maxIdx], maxVal);

        }

        float[] RunModel(ByteBuffer inputBuffer)
        {
            // Step 1: Get output tensor shape (e.g., [1, 102])
            int[] shape = interpreter.GetOutputTensor(0).Shape();
            int typeSize = 4; // float32 = 4 bytes
            int outputSize = shape.Aggregate((a, b) => a * b);  // Multiply all dimensions

            // Step 2: Allocate a direct ByteBuffer for the output
            ByteBuffer outputBuffer = ByteBuffer.AllocateDirect(outputSize * typeSize);
            outputBuffer.Order(ByteOrder.NativeOrder());

            // Step 3: Run inference
            interpreter.Run(inputBuffer, outputBuffer);

            // Step 4: Extract float[] from ByteBuffer
            outputBuffer.Rewind();
            float[] output = new float[outputSize];

            for (int i = 0; i < outputSize; i++)
            {
                output[i] = outputBuffer.GetFloat(i);
            }

            float[] probs = Softmax(output);
            return probs;
        }

        float[] Softmax(float[] logits)
        {
            float maxLogit = logits.Max(); // For numerical stability
            /*
            float sumExp = 0f;
            float[] exps = new float[logits.Length];

            for (int i = 0; i < logits.Length; i++)
            {
                exps[i] = (float)Math.Exp(logits[i] - maxLogit);
                sumExp += exps[i];
            }
            */
            float[] probabilities = new float[logits.Length];
            for (int i = 0; i < logits.Length; i++)
            {
                probabilities[i] = logits[i] / maxLogit;
            }

            return probabilities;
        }

        private ByteBuffer ConvertBitmapToByteBuffer(Bitmap bitmap)
        {
            var buffer = ByteBuffer.AllocateDirect(4 * inputSize * inputSize * 3);
            buffer.Order(ByteOrder.NativeOrder());

            int[] intValues = new int[inputSize * inputSize];
            bitmap.GetPixels(intValues, 0, inputSize, 0, 0, inputSize, inputSize);

            foreach (int pixel in intValues)
            {
                buffer.PutFloat(((pixel >> 16) & 0xFF) / 255f); // R
                buffer.PutFloat(((pixel >> 8) & 0xFF) / 255f);  // G
                buffer.PutFloat((pixel & 0xFF) / 255f);         // B
            }

            return buffer;
        }
    }

}
