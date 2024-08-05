function mahasiswaPicker(data) {
    const { inputName, multi, containerInput, tablePreview, buttonSelesai, tableData, pilihSemua } = data;

    buttonSelesai.on('click', () => {
        containerInput.html('');
        tablePreview.html('');

        tableData.each((index, item) => {
            const mahasiswa = {
                selected: $(item).find('input#selected').prop('checked'),
                id: $(item).find('input#id').val(),
                nim: $(item).find('input#nim').val(),
                nama: $(item).find('input#nama').val(),
            };

            if (mahasiswa.selected) {
                containerInput.append(`<input name="${inputName}" id="${inputName}" value="${mahasiswa.id}" hidden type="text" readonly />`);
                tablePreview.append(`<tr><td>${mahasiswa.nim}</td><td>${mahasiswa.nama}</td></tr>`);
            }
        });
    });

    if (!multi) {
        let indexTerpilih = null;

        const updateUI = () => {
            tableData.each((item, index) => {
                if (index === indexTerpilih) {
                    $(item).find('input#selected').prop('checked', true);
                } else {
                    $(item).find('input#selected').prop('checked', false);
                }
            });
        }

        tableData.each((item, index) => {
            $(item).find('input#selected').on('click', function () {
                $(this).prop('checked', true);
                indexTerpilih = index;
                updateUI();
            })
        });

        const idMahasiswa = containerInput.find(`input#${inputName}`).first().val();
        if (idMahasiswa) {
            tableData.filter((index, item) => $(item).find('input#id').val() == idMahasiswa)
                .first().find('input#selected').prop('checked', true);
        }
    } else {
        containerInput.find(`input#${inputName}`).each((index, item) => {
            const idMahasiswa = $(item).val();
            tableData.filter((index, item) => $(item).find('input#id').val() == idMahasiswa)
                .first().find('input#selected').prop('checked', true);
        });

        pilihSemua.on('change', () => {
            const checked = pilihSemua.prop('checked');

            tableData.each((index, item) => {
                $(item).find('input#selected').prop('checked', checked);
            });
        });
    }
}