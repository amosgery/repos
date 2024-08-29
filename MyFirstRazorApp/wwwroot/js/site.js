// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    form = document.getElementById('registerForm');// register form
    if (form == null)  
        form = document.getElementById('updateForm'); // update form
    if (form == null)
        return;  // other pages - do nothing
    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const firstName = document.getElementById('firstName');
    const lastName = document.getElementById('lastName');
    const birthdate = document.getElementById('birthdate');
    const phone = document.getElementById('phone');
    const email = document.getElementById('email');
    const genderMale = document.getElementById('genderMale');
    const genderFemale = document.getElementById('genderFemale');
    const genderOther = document.getElementById('genderOther');

    const occupation = document.getElementById('occupation');
    const admin = document.getElementById('admin');

    const usernameError = document.getElementById('usernameError');
    const passwordError = document.getElementById('passwordError');
    const firstNameError = document.getElementById('firstNameError');
    const lastNameError = document.getElementById('lastNameError');
    const birthdateError = document.getElementById('birthdateError');
    const phoneError = document.getElementById('phoneError');
    const emailError = document.getElementById('emailError');

    const genderError = document.getElementById('genderError');
    const occupationError = document.getElementById('occupationError');

    // Validate on input
    username.addEventListener('input', validateUsername);
    password.addEventListener('input', validatePassword);
    firstName.addEventListener('input', validateFirstName);
    lastName.addEventListener('input', validateLastName);
    birthdate.addEventListener('input', validateBirthdate);
    phone.addEventListener('input', validatePhone);
    occupation.addEventListener('input', validateOccupation);
    email.addEventListener('input', validateEmail);

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        let isValid = true;
        // Validate fields
        if (!validateUsername()) isValid = false;
        if (!validatePassword()) isValid = false;
        if (!validateFirstName()) isValid = false;
        if (!validateLastName()) isValid = false;
        if (!validateBirthdate()) isValid = false;
        if (!validateGender()) isValid = false;
        if (!validatePhone()) isValid = false;
        if (!validateEmail()) isValid = false;
        if (!validateOccupation()) isValid = false;

        if (isValid) {
            //alert('Form submitted successfully!');
            form.submit();
        } else {
            alert('Please correct the errors in the form.');
        }
        // Clear previous errors
        clearErrors();
    });

    function validateUsername() {
        const value = username.value.trim();
        if (value.length < 3) {
            usernameError.textContent = 'Username must be at least 3 characters long.';
            return false;
        }
        usernameError.textContent = '';
        return true;
    }

    function validatePassword() {
        const value = password.value.trim();
        if (value.length < 6) {
            passwordError.textContent = 'Password must be at least 6 characters long.';
            return false;
        }
        passwordError.textContent = '';
        return true;
    }

    function validateFirstName() {
        const value = firstName.value.trim();
        if (value === '') {
            firstNameError.textContent = 'First name is required.';
            return false;
        }
        firstNameError.textContent = '';
        return true;
    }

    function validateLastName() {
        const value = lastName.value.trim();
        if (value === '') {
            lastNameError.textContent = 'Last name is required.';
            return false;
        }
        lastNameError.textContent = '';
        return true;
    }

    function validateBirthdate() {
        const value = birthdate.value;
        if (value === '') {
            birthdateError.textContent = 'Birthdate is required.';
            return false;
        }
        birthdateError.textContent = '';
        return true;
    }

    function validatePhone() {
        const value = phone.value;
        const regexp = /^[0-9]+$/;
        if (value.length < 9) {
            phoneError.textContent = 'Phone number should be at least 9 digits long.';
            return false;
        }
        if (value.length > 10) {
            phoneError.textContent = 'Phone number should be less than 10 digits long.';
            return false;
        }
        if (!regexp.test(value)) {
            phoneError.textContent = 'Phone number should contain only numbers.';
            return false;
        }
        phoneError.textContent = '';
        return true;
    }

    function validateEmail() {
        const value = email.value;
        if (value === '') {
            emailError.textContent = 'Email is not valid.';
            return false;
        }
        emailError.textContent = '';
        return true;
    }
    function validateGender() {
        if (genderMale.checked || genderFemale.checked || genderOther.checked) {
                genderError.textContent = '';
                return true;
        }

        genderError.textContent = 'Gender is required.';
        return false;
    }

    function validateOccupation() {
        const value = occupation.value;
        if (value === '') {
            occupationError.textContent = 'Occupation is required.';
            return false;
        }
        occupationError.textContent = '';
        return true;
    }

    function clearErrors() {
        usernameError.textContent = '';
        passwordError.textContent = '';
        firstNameError.textContent = '';
        lastNameError.textContent = '';
        birthdateError.text = '';
        occupationError.text = '';
        phoneError.text = '';
        emailError.text = '';
    }
})