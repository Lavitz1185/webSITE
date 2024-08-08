$.validator.addMethod("sensorkatakasar", function (value, element, params) {
    const daftarKataKasar = params[0];
    const words = value.toLowerCase().split(' ');

    for (let word of words) {
        if (daftarKataKasar.some(x => x.includes(word))) {
            return false;
        }
    }

    return true;
});

$.validator.unobtrusive.adapters.add("sensorkatakasar", ["daftarkatakasar"], function (options) {
    options.rules["sensorkatakasar"] = [JSON.parse(options.params["daftarkatakasar"])];
    options.messages["sensorkatakasar"] = options.message;
});