function validateReg() {
 
    var name = document.getElementById("name").value.trim();
    var email = document.getElementById("email").value.trim();
    var phone = document.getElementById("phone").value.trim();
    var password = document.getElementById("password").value.trim();
    var confirmPassword = document.getElementById("confirm_password").value.trim();
    var address = document.getElementById("address").value.trim();
    var file = document.getElementById("file").files[0];

 
    const errors = {
        nameErr: "error_Name",
        emailErr: "error_email",
        phoneErr: "error_phone",
        passErr: "error_password",
        conPassErr: "error_confirm_password",
        addrErr: "error_address",
        fileErr: "error_file",
    };

   
    Object.values(errors).forEach((id) => {
        document.getElementById(id).innerHTML = "";
    });

    let isValid = true;

   
    if (name.length < 3) {
        document.getElementById(errors.nameErr).innerHTML = "Name must be at least 3 characters.";
        isValid = false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        document.getElementById(errors.emailErr).innerHTML = "Invalid email format.";
        isValid = false;
    }

    if (!/^\d{11}$/.test(phone)) {
        document.getElementById(errors.phoneErr).innerHTML = "Phone number must be exactly 11 digits.";
        isValid = false;
    }

    if (password.length < 6) {
        document.getElementById(errors.passErr).innerHTML = "Password must be at least 6 characters.";
        isValid = false;
    }

    if (password !== confirmPassword) {
        document.getElementById(errors.conPassErr).innerHTML = "Passwords do not match.";
        isValid = false;
    }

    if (address.length < 3) {
        document.getElementById(errors.addrErr).innerHTML = "Address must be at least 3 characters.";
        isValid = false;
    }

    if (!file) {
        document.getElementById(errors.fileErr).innerHTML = "Profile picture is required.";
        isValid = false;
    }

   
    return isValid;
}


function validatePayment() {
    
    var phone = document.getElementById("ac").value.trim();
    var password = document.getElementById("password").value.trim();
    var paymentMethod = document.getElementById("payment_method").value.trim();

    
    const errors = {
        phoneErr: "error_phone",
        passErr: "error_password",
        paymentErr: "error_payment_method",
    };

    
    Object.values(errors).forEach((id) => {
        document.getElementById(id).innerHTML = "";
    });

    let isValid = true;

    
    if (!/^\d{11}$/.test(phone)) {
        document.getElementById(errors.phoneErr).innerHTML = "Phone number must be exactly 11 digits and contain only numbers.";
        isValid = false;
    }

   
    if (password.length < 5) {
        document.getElementById(errors.passErr).innerHTML = "Password must be at least 5 characters long.";
        isValid = false;
    }

   
    if (paymentMethod === "") {
        document.getElementById(errors.paymentErr).innerHTML = "Please select a payment method.";
        isValid = false;
    }


    return isValid;
}
