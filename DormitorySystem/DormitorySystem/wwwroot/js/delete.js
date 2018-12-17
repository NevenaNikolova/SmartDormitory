$((function () {
    var url;
    var redirectUrl;
    var target;

    $(".delete").on('click', (e) => {
        e.preventDefault();

        target = e.target;
        var Id = $(target).attr("data-id")       
        console.log(Id);
        var area = $(target).attr("data-area");
        var controller = $(target).attr("data-controller");
        console.log(controller);
        var action = $(target).attr("data-action");
        console.log(action);
        var bodyMessage = $(target).attr("data-body-message");
        console.log(bodyMessage);
        redirectUrl = $(target).attr("data-redirect-url");
        console.log(redirectUrl);
        url = "/" + area + "/" + controller + "/" + action + "?Id=" + Id;
        console.log(url);
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal('show');
    });

    $("#confirm-delete").on('click', () => {
        $.get(url)
            .done((result) => {
                if (!redirectUrl) {
                    return $(target).parent().parent().hide("slow");
                }
                window.location.href = redirectUrl;
            })
            .fail((error) => {
                if (redirectUrl)
                    window.location.href = redirectUrl;
            }).always(() => {
                $("#deleteModal").modal('hide');
            });
    });

}()));