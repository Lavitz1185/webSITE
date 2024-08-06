function fotoPicker(data) {
    const { id, inputName, multi, TambahVMFormFile } = data;

    const inputContainer = $(`#input-container${id}`);
    const preview = $(`#previewFoto${id}`);
    const selectedClass = 'selected';
    const buttonSelesai = $(`#modal${id} button#selesai`);
    const buttonUpload = $(`#modal${id} #uploadFoto`);

    const makeGetUrl = (id) => `/File/Foto/${id}`;

    let daftarFotoContainer = $(`#modal${id} .foto-container`);
    let idFotoTerpilih = 0;
    let daftarIdFoto = [];

    const updateUI = () => {
        daftarFotoContainer.each((index, item) => {
            const idFoto = $(item).find('input#fotoId').val();

            if (idFoto === idFotoTerpilih) {
                $(item).addClass(selectedClass);
            } else {
                $(item).removeClass(selectedClass);
            }
        });
    };

    const onFotoContainerClick = function () {
        const selected = $(this).hasClass(selectedClass);
        const idFoto = $(this).find('input#fotoId').val();

        if (multi) {
            if (selected) {
                daftarIdFoto = [...daftarIdFoto.filter((value) => value !== idFoto)];
            } else {
                daftarIdFoto.push(idFoto);
            }

            $(this).toggleClass(selectedClass);
        } else {
            idFotoTerpilih = idFoto;
            updateUI();
        }
    };

    buttonSelesai.on('click', function () {
        preview.html('');
        inputContainer.html('');

        if (multi) {
            for (let idFoto of daftarIdFoto) {
                inputContainer.append(`<input type="text" name="${inputName}" id="${inputName}" value="${idFoto}" hidden />`);
                preview.append(`<img src="${makeGetUrl(idFoto)}" class="img-fluid"/>`)
            }
        } else {
            if (idFotoTerpilih !== 0) {
                inputContainer.append(`<input type="text" name="${inputName}" id="${inputName}" value="${idFotoTerpilih}" hidden />`);
                preview.append(`<img src="${makeGetUrl(idFotoTerpilih)}" class="img-fluid"/>`)
            }
        }
    });

    const init = () => {
        daftarFotoContainer.each((index, item) => $(item).on('click', onFotoContainerClick));

        if (multi) {
            inputContainer.find(`input#${inputName}`).each((index, item) => {
                const idFoto = $(item).val();
                daftarIdFoto.push(idFoto);
                daftarFotoContainer
                    .filter((index, item) => $(item).find('input#fotoId').val() == idFoto)
                    .first().addClass(selectedClass);
            });
        } else {
            const idFoto = inputContainer.find(`input#${inputName}`).first().val();
            if (idFoto) {
                idFotoTerpilih = idFoto;
                daftarFotoContainer
                    .filter((index, item) => $(item).find('input#fotoId').val() == idFoto)
                    .first().addClass(selectedClass);
            }
        }
    }

    buttonUpload.on('click', async function () {
        const formData = new FormData();
        const inputFile = $(`#modal${id} #formFile`)[0].files[0];

        formData.append(TambahVMFormFile, inputFile);

        $(`#modal${id} #formFileVal`).html('');

        $(this).html('');
        $(this).append('Loading...');
        $(this).prop('disabled', true);

        const response = await fetch(
            '/Dashboard/Foto/Tambah?isJson=true',
            {
                credentials: 'same-origin',
                method: "POST",
                body: formData,
            }
        );

        if (response.ok) {
            const data = await response.json();

            console.log(daftarFotoContainer.first());

            const newFotoContainer = `<div class="col-3 p-1 foto-container">
                                        <input type="text" id="fotoId" value="${data}" hidden />
                                        <img class="img-thumbnail" src="${makeGetUrl(data)}" />
                                      </div>`;

            let elementCount = 0;

            daftarFotoContainer.each((index, item) => elementCount++);

            if (elementCount > 0) {
                daftarFotoContainer.first().before(newFotoContainer);
            } else {
                $(`#fotoGrid${id}`).html(newFotoContainer);
            }

            daftarFotoContainer = $(`#modal${id} .foto-container`);

            daftarFotoContainer
                .filter((index, item) => $(item).find('input#fotoId').val() == data)
                .first().on('click', onFotoContainerClick);
                
            $(`#modal${id} #formFile`).val('');
        } else {
            const data = await response.json();

            $(`#modal${id} #formFileVal`).html('');
            $(`#modal${id} #formFileVal`).append(data['@(nameof(TambahVM.FormFile))']);
        }

        $(this).html('');
        $(this).append('Upload');
        $(this).prop('disabled', false);
    });

    init();
}