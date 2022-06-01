function runIntro(object) {

    $('[data-intro]:hidden').each(function (index, obj) {
        var $t = $(this);
        $t
            .attr({
                'data-intro-hidden': $t.attr('data-intro'),
            })
            .removeAttr('data-intro')
            ;
    });

    $('[data-intro-hidden]:visible').each(function (index, obj) {
        var $t = $(this);
        $t
            .attr({
                'data-intro': $t.attr('data-intro-hidden'),
            })
            .removeAttr('data-intro-hidden')
            ;
    });

    if (typeof object === undefined)
        introJs().start();
    else
        introJs(object).start();
}
function validation_check() {
    'use strict'
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
}