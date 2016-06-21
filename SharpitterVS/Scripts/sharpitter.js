$(document).ready(function(){

    $('.postar-texto').focusin(function(){
        $('.postar').addClass('postar-hover');
    });

    /*$('.postar-texto').focusout(function(){
        $('.postar').removeClass('postar-hover');
    });*/

    $('.postar-texto').keyup(function(){
        limita($(this));
    });

    function limita(campo){
        var tamanho = campo.val().length();
        var tex = campo.val();
        if (tamanho >= 160) {
            campo.val(tex.substring(0,160));
        }
        return true;
    }
});