$(document).ready(function () {
    $.getJSON("/home/getAllStates", function (states) {
        if (states) {
            var ddlState = $("#StateId");
            ddlState.empty().append('<option value=""> Select State </option>');

            $.each(states, function (i, state) {
                ddlState.append($("<option>", {
                    value: state.id,
                    text: state.name
                }));
            });

            var stateId = $("#hdnStateId").val();
            if (stateId) {
                ddlState.val(stateId);
            }
        }
    });

    var fullAddress = $("#hdnFullAddress").val();
    if (fullAddress) {
        $("#FullAddress").val(fullAddress);
    }
    var userId = $("#hdnUserId").val();
    if (userId && userId !== "0") {
        $("button[type='submit']").text("Update");
        
        $("#MainHeader").text("Edit User");
    }
});
