showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');   
                    toastr.success(res.message);

                    setTimeout(location.reload.bind(location), 2000);
                }
                else
                    $('#form-modal .modal-body').html(res.html);

            },
            
            error: function (err) {
                console.log(err),
                    toastr.error(res.message);
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}



/*                   */
jQueryAjaxDelete = form => {
    Swal.fire({
        title: 'Vous êtes sûr?',
        text: "si vous continuer cette action, le fichier va être supprimé!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Oui, continuer!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                    toastr.success(res.message);

                    Swal.fire(
                        'Supprimé!',
                        'Votre fichier a été supprimé!',
                        'success'
                    )
                },
                error: function (res) {
                    toastr.error(res.message);
                }
            })
        }
    })

    //prevent default form submit event
    return false;
}


jQueryAjaxConvert = form => {

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger m-2'
        },
        buttonsStyling: false
    })
    swalWithBootstrapButtons.fire({
        title: 'Vous êtes sûr?',
        text: "Cette action va créer une nouvelle facture d'aprés la proposition courante !",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Oui, Continuer ',
        cancelButtonText: 'Non, annuler',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                    toastr.success(res.message);

                    swalWithBootstrapButtons.fire(
                        'Cool!',
                        'Nouvelle facture crée!',
                        'success'
                    )
                },
                error: function (res) {
                    toastr.error(res.message);
                }
            })
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Annulé',
                'Action annulé :)',
                'error'
            )
        }
    })

    //prevent default form submit event
    return false;
}
/*    */

/*    */

