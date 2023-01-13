class Validator {
    isValid(str) {
        throw new Error("Validator is an abstract class");
    }
}

class PhoneValidator extends Validator {
    isValid(str) {
        let pattern = RegExp(/^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$/g);
        return pattern.test(str);
    }
}

class EmailValidator extends Validator {
    isValid(str) {
        let pattern = RegExp(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/);
        return pattern.test(str);
    }
}