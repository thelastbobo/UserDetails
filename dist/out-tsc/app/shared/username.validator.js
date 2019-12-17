export function forbiddenNameValidator(control) {
    const forbidden = /admin/.test(control.value);
    return forbidden ? {
        'forbiddenName': { value: control.value }
    } : null;
}
//# sourceMappingURL=username.validator.js.map