$(document).ready(function ()
{
    $('#submit').click(function (e)
    {
        e.preventDefault();
        var isAllValid = true;
        var validator = $("#MainForm").kendoValidator().data("kendoValidator");
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele)
        {
            if ($('.ProductName', this).val() === "") {
                alert("Faltan Instrucciones por verificar, por favor verifique todas las instrucciones.");

              errorItemCount++;
            }
                else
            {
                var orderItem =
                {
                    ProductName: $('.ProductName', this).val()
                }
                list.push(orderItem);
            }

        })

        if (errorItemCount > 0)
        {
            $('#orderItemError').text(errorItemCount + "instruccione(s) faltantes de verificar");
            $('#orderItemError').css('display', 'block');
            isAllValid = false;
        }


        if (validator.validate() && isAllValid)
        {
            var data ={         
                ProductName: $('#ProductName').val(),
               AreaID: $('#AreaID').val(),
                ProductInternalArea: $('#ProductInternalArea').val(),
                ProductType: $('#ProductType').val()
            }

            $.ajax(
            {
                type: 'POST',
                url: '/Shipping_Catalog_Products/Create',
                data: JSON.stringify(data),
                /*data: JSON.stringify({
                    ProductName: $('#ProductName').val(),
                    AreaID: $('#AreaID').val(),
                    ProductInternalArea: $('#ProductInternalArea').val(),
                    ProductType: $('#ProductType').val()
                }),*/
                contentType: 'application/json',
                success: function (data)
                {
                   /* if (data.status)
                    {*/
                        swal(
                        {
                            type: 'warning',
                            title: 'Por favor, espere mientras se verifica',
                            showComfirmButton: false,
                            timer: 3000,
                            allowOutsideClick: false,
                            onOpen: () =>
                            {
                                swal.showLoading()
                            },
                                onBeforeOpen: function ()
                                {
                                    $(".swal2-popup").css(
                                    {
                                        "font-size": 1.3 + 'rem',
                                    })
                                }
                        })
                            var time

                        time = window.setTimeout(linkToIndex, 1000); function linkToIndex()
                        {
                            window.location.href = data.url;
                        }
                     /*}
                       else
                    {
                        swal(
                        {
                            type: 'error',
                            title: 'Hay un problema...',
                            text: 'Faltan Instrucciones por verificar, por favor verifique todas las instrucciones.!',
                            showCloseButton: 'true',
                            allowOutsideClick: false,
                            onBeforeOpen: function ()
                            {
                                $(".swal2-popup").css(
                                {
                                    "font-size": 1.3+'rem',
                                })                                
                            }
                        })                        
                    }*/
                },
                    error: function (error)
                    {
                        console.log(error);
                    }
            });
        }
    })
})