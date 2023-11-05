
/*BOTAO DE EDITAR O FORMULARIO*/
$(document).ready(function () {
    $('#editarButton').click(function () {
        // Quando o botão "Editar" é clicado, remova o atributo "readonly" dos campos de entrada.
        $('input[type="text"]').prop('readonly', false);
        $('select').prop('disabled', false);

        // Altere o valor do botão "Editar" para "Salvar" (opcional).
        $(this).val("Cancelar");
    });
});

$(document).ready(function () {
    let isEditing = false;

    $('#editarButton2').click(function () {
        if (isEditing) {
            // Se o usuário estava editando e clicou novamente, cancelar a ação.
            $('input[readonly]').prop('readonly', true);
            $(this).text("Editar");
        } else {
            // Se o usuário não estava editando e clicou para editar, permitir a edição.
            $('input[readonly]').prop('readonly', false);
            $(this).text("Cancelar");
        }

        isEditing = !isEditing;
    });
});




//CONFIGURANDO A SAIDA DO CPF
document.getElementById('cpfInput').addEventListener('input', function (e) {
    var value = e.target.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos
    var formattedValue = formatCPF(value); // Formata o CPF
    e.target.value = formattedValue; // Define o valor formatado de volta no campo
});

function formatCPF(value) {
    if (value.length >= 4) {
        return value.substring(0, 3) + '.' + value.substring(3, 6) + '.' + value.substring(6, 9) + '-' + value.substring(9, 11);
    }
    return value;
}