$('document').ready(function () {
    var _id = $('.imgshow').attr('id');
    showImg();
    $("#imgload").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                if (e.target.result == $('.pro-cate-img img').attr('src')) {

                }
                else {                
                    var img = $('#imgload').val().slice(12);
                    $('.imgshow button').click(function (e) {
                        $(this).parent('div').remove();
                    })
                    $.ajax({
                        url: "/Admin/SanPham/AddImg",
                        method: "POST",
                        data: { imgPath: img, id: _id },
                        success: function (result) {
                            showImg();
                            console.log(result)
              
                        },
                        error: function () {

                            console.log("lỗi")
                        }
                    })
                    
                }
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
    function showImg() {

    $.ajax({
        url: "/Admin/SanPham/EditImg",
        method: "POST",
        data: {id: _id },
        success: function (result) {
            var rs = $.map(result, function (item) {
                console.log(item.id)
                return `<div class="m-1 pro-cate-img" id="${item.id}" style="width:200px;height:200px">

                                            <img src="~/assets/images/products/${item.img}" style="width:100%;height:100%" />
                                            <button>
                                                <i class="fas fa-times"></i>
                                            </button>
                                        </div>`
            }
            )
            console.log(result)
            const rss = rs.join('');
            $('.imgshow').html(rss);
            $('.pro-cate-img button').click(function (e) {

                $.ajax({
                    url: "/Admin/SanPham/DeleteImg",
                    method: "POST",
                    data: { id: $('.pro-cate-img').attr('id') },
                    success: function (result) {
                        showImg();
                        console.log(result)

                    },
                    error: function () {

                        console.log("lỗi")
                    }
                })

            })
        },
        error: function () {

            console.log("lỗi")
        }
    })
    }   
   

});
