function DeleteUser(userId) {
    Swal.fire({
        title: "Are you sure?",
        text: "Are you sure you want to delete this user!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
  
                $.ajax({
                    url: '/Home/DeleteUser',
                    type: 'POST',
                    data: { userId: userId }, 
                    success: function (response) {
                        if (response.success) {
                            Swal.fire({
                                title: "Deleted!",
                                text: "User has been deleted.",
                                icon: "success"
                            });
                            $("#row-" + userId).remove();
                        } else {
                            alert(response.message);
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error(error);
                        alert("An error occurred while deleting the user.");
                    }
                });

            
        }
    });

}