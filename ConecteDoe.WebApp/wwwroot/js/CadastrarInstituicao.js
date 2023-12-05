// MASCARA E BUSCA CEP//
function mascara(o, f) {
    v_obj = o;
    v_fun = f;
    setTimeout("execmascara()", 1);
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value);
}

function mtel(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/g, "($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d)(\d{4})$/, "$1-$2"); //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}

function mcep(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito
    v = v.replace(/(\d)(\d{3})$/, "$1-$2"); //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}

function id(el) {
    return document.getElementById(el);
}

function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    id('rua').value = ("");
    id('bairro').value = ("");
    id('cidade').value = ("");
    id('estado').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        id('rua').value = (conteudo.logradouro);
        id('bairro').value = (conteudo.bairro);
        id('cidade').value = (conteudo.localidade);
        id('estado').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        /*alert("CEP não encontrado.");*/
        Swal.fire({
            title: 'Erro!',
            text: "CEP não encontrado.",
            icon: 'error',
            confirmButtonColor: '#abed1a',
            confirmButtonText: 'Ok'
        })
    }
}

function pesquisacep(valor) {
    // Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    // Verifica se campo cep possui valor informado.
    if (cep != "") {
        // Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        // Valida o formato do CEP.
        if (validacep.test(cep)) {
            id('cep').value = cep.substring(0, 5) + "-" + cep.substring(5);

            // Preenche os campos com "..." enquanto consulta webservice.
            id('rua').value = "...";
            id('bairro').value = "...";
            id('cidade').value = "...";
            id('estado').value = "...";

            // Cria um elemento javascript.
            var script = document.createElement('script');

            // Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            // Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);
        } //end if.
        else {
            // cep é inválido.
            limpa_formulário_cep();
            /*alert("Formato de CEP inválido.");*/
            Swal.fire({
                title: 'Erro!',
                text: "Formato de CEP inválido.",
                icon: 'error',
                confirmButtonColor: '#abed1a',
                confirmButtonText: 'Ok'
            })
        }
    } //end if.
    else {
        // cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
};


// MASCARA E VALIDACAO CPF
function mascaraCPF(cpf) {
    cpf = cpf.replace(/\D/g, ""); // Remove tudo o que não é dígito
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Coloca ponto entre o terceiro e o quarto dígitos
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Coloca ponto entre o sexto e o sétimo dígitos
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2"); // Coloca hífen entre o nono e o décimo dígitos
    return cpf;
}

function validaCPF(cpf) {
    cpf = cpf.replace(/\D/g, ""); // Remove tudo o que não é dígito

    if (cpf.length !== 11 || /^(\d)\1{10}$/.test(cpf)) {
        return false; // CPF inválido
    }

    let sum = 0;
    let remainder;

    for (let i = 1; i <= 9; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }

    remainder = (sum * 10) % 11;

    if ((remainder === 10) || (remainder === 11)) {
        remainder = 0;
    }

    if (remainder !== parseInt(cpf.substring(9, 10))) {
        return false; // CPF inválido
    }

    sum = 0;
    for (let i = 1; i <= 10; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }

    remainder = (sum * 10) % 11;

    if ((remainder === 10) || (remainder === 11)) {
        remainder = 0;
    }

    if (remainder !== parseInt(cpf.substring(10, 11))) {
        return false; // CPF inválido
    }

    return true; // CPF válido
}

// MASCARA E VALIDACAO CNPJ
function mascaraCNPJ(cnpj) {
    cnpj = cnpj.replace(/\D/g, ""); // Remove tudo o que não é dígito
    cnpj = cnpj.replace(/^(\d{2})(\d)/, "$1.$2"); // Coloca ponto entre o segundo e o terceiro dígitos
    cnpj = cnpj.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3"); // Coloca ponto entre o quinto e o sexto dígitos
    cnpj = cnpj.replace(/\.(\d{3})(\d)/, ".$1/$2"); // Coloca barra entre o oitavo e o nono dígitos
    cnpj = cnpj.replace(/(\d{4})(\d)/, "$1-$2"); // Coloca hífen entre o décimo segundo e o décimo terceiro dígitos
    return cnpj;
}

function validaCNPJ(cnpj) {
    cnpj = cnpj.replace(/\D/g, ""); // Remove tudo o que não é dígito

    if (cnpj.length !== 14 || /^(\d)\1{13}$/.test(cnpj)) {
        return false; // CNPJ inválido
    }

    let size = cnpj.length - 2;
    let numbers = cnpj.substring(0, size);
    const digits = cnpj.substring(size);
    let sum = 0;
    let pos = size - 7;

    for (let i = size; i >= 1; i--) {
        sum += parseInt(numbers.charAt(size - i)) * pos--;
        if (pos < 2) {
            pos = 9;
        }
    }

    let result = sum % 11 < 2 ? 0 : 11 - sum % 11;

    if (result !== parseInt(digits.charAt(0))) {
        return false; // CNPJ inválido
    }

    size = size + 1;
    numbers = cnpj.substring(0, size);
    sum = 0;
    pos = size - 7;

    for (let i = size; i >= 1; i--) {
        sum += parseInt(numbers.charAt(size - i)) * pos--;
        if (pos < 2) {
            pos = 9;
        }
    }

    result = sum % 11 < 2 ? 0 : 11 - sum % 11;

    return result === parseInt(digits.charAt(1)); // CNPJ válido
}

// Example of how to use the CPF mask and validation
window.onload = function () {
    id('telefone').onkeyup = function () {
        mascara(this, mtel);
    }

    id('cep').onkeyup = function () {
        mascara(this, mcep);
    }

    id('cep').onblur = function () {
        pesquisacep(this.value);
    }

    id('cpf').onkeyup = function () {
        this.value = mascaraCPF(this.value);
    }

    id('cpf').onblur = function () {
        if (!validaCPF(this.value)) {
            /*alert("CPF inválido. Por favor, digite um CPF válido.");*/
            Swal.fire({
                title: 'Erro!',
                text: "CPF inválido. Por favor, digite um CPF válido.",
                icon: 'error',
                confirmButtonColor: '#abed1a',
                confirmButtonText: 'Ok'
            })
            this.value = "";
        }
    }

    id('cnpj').onkeyup = function () {
        this.value = mascaraCNPJ(this.value);
    }

    id('cnpj').onblur = function () {
        if (!validaCNPJ(this.value)) {
            /*alert("CNPJ inválido. Por favor, digite um CNPJ válido.");*/
            Swal.fire({
                title: 'Erro!',
                text: "CNPJ inválido. Por favor, digite um CNPJ válido.",
                icon: 'error',
                confirmButtonColor: '#abed1a',
                confirmButtonText: 'Ok'
            })
            this.value = "";
        }
    }
};

