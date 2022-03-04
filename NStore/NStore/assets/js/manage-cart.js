var isCustomerLogin = $("#isCustomerLogin").val();

function LoadCart_Layout() {
    const dropdownCart = document.querySelector("#dropdown-cart");
    if (isCustomerLogin == 1 && dropdownCart) {
        $.ajax({
            url: "/User/GetListCart",
            type: "POST",
            success: (result) => {
                let html = `<a href="#" class="dropdown-toggle" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static">
                                <i class="icon-shopping-cart"></i>
                                <span class="cart-count">${result.length}</span>
                                <span class="cart-txt">Giỏ Hàng</span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right">
                                <div class="dropdown-cart-products">`;
                result.forEach((item) => {
                html += `           <div class="product">
                                        <div class="product-cart-details">
                                            <h4 class="product-title">
                                                <a href="#">${item.tenSanPham}</a>
                                            </h4>

                                            <span class="cart-product-info">
                                                <span class="cart-product-qty">${item.soLuong}</span>
                                                x ${(item.donGia - item.donGia*item.giamGia/100).toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}
                                            </span>
                                        </div><!-- End .product-cart-details -->

                                        <figure class="product-image-container">
                                            <a href="#" class="product-image">
                                                <img src="/assets/images/products/${item.img}" alt="product">
                                            </a>
                                        </figure>
                                    </div><!-- End .product -->`;
                })
                html += `       </div><!-- End .cart-product -->
                                <div class="dropdown-cart-total">
                                    <span>Tổng</span>
                                    <span class="cart-total-price">`;
                let total = 0;
                result.forEach((item) => { total += (item.donGia - item.donGia*item.giamGia/100) * item.soLuong });
                html += `           ${total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</span>
                                </div><!-- End .dropdown-cart-total -->

                                <div class="dropdown-cart-action">
                                    <a href="/User/Cart" class="btn btn-primary">Xem Giỏ Hàng</a>
                                </div><!-- End .dropdown-cart-action -->
                            </div><!--End.dropdown - menu-- >`;
                dropdownCart.innerHTML = html;
            },
            error: (err) => {
                console.log("Lỗi hiển thị giỏ hàng tại layout");
            }
        })
    }
}

function LoadCartTable() {
    const tableCart = document.querySelector(".table-cart tbody");
    if (isCustomerLogin == 1 && tableCart) {
        $.ajax({
            url: "/User/GetListCart",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: (result) => {
                let html = '';
                result.forEach((item) => {
                    html += `<tr>
                                <td class="product-col">
                                    <div class="product">
                                        <figure class="product-media">
                                            <a href="#">
                                                <img src="/assets/images/products/${item.img}" alt="Product image">
                                            </a>
                                        </figure>

                                        <h3 class="product-title">
                                            <a href="#">${item.tenSanPham}</a>
                                        </h3><!-- End .product-title -->
                                    </div><!-- End .product -->
                                </td>
                                <td class="price-col">${(item.donGia - item.donGia*item.giamGia/100).toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
                                <td class="quantity-col">
                                    <div class="cart-product-quantity">
                                        <input type="number" class="form-control" value="${item.soLuong}" min="1" max="10000" step="1" data-decimals="0" required>
                                    </div><input type="hidden" value=${item.idSanPham} />
                                </td>
                                <td class="total-col">${((item.donGia - item.donGia * item.giamGia / 100) * item.soLuong).toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
                                <td class="remove-col"><button onclick="RemoveFromCartClick(${item.id})" class="btn-remove"><i class="icon-close"></i></button></td>
                            </tr>`;
                });
                tableCart.innerHTML = html;
                GetTotal_CartPrice();
                quantityInputs();
            },
            error: (err) => {
                console.log("Lỗi hiển thị giỏ hàng tại layout");
            }
        })
    }
}

function quantityInputs() {
    if ($.fn.inputSpinner) {
        $("input[type='number']").inputSpinner({
            decrementButton: '<i class="icon-minus"></i>',
            incrementButton: '<i class="icon-plus"></i>',
            groupClass: 'input-spinner',
            buttonsClass: 'btn-spinner',
            buttonsWidth: '26px'
        });

        document.querySelectorAll(".input-spinner").forEach((e) => {
            var timeout = null;

            e.querySelector("input").addEventListener("keyup", (event) => {
                clearTimeout(timeout);
                timeout = setTimeout(() => {
                    let productId = event.target.parentNode.parentNode.nextSibling.value;
                    let soLuong = event.target.value;
                    if (soLuong >= 1 && soLuong <= 10000) {
                        AddToCart(productId, soLuong);
                    } else {
                        alert("Số lượng nằm trong khoảng 1-10000");
                    }
                }, 800);
            })

            e.querySelector(".btn-decrement").addEventListener("click", () => {
                let productId = e.parentNode.nextSibling.value;
                let soLuong = e.querySelector("input").value;
                AddToCart(productId, soLuong);
            })

            e.querySelector(".btn-increment").addEventListener("click", () => {
                let productId = e.parentNode.nextSibling.value;
                let soLuong = e.querySelector("input").value;
                AddToCart(productId, soLuong);
            })
        })
    }
}

function GetTotal_CartPrice() {
    if (isCustomerLogin == 1) {
        $.ajax({
            url: "/User/GetTotal_CartPrice",
            type: "POST",
            success: (result) => {
                document.querySelector("#cart-summary-total").innerHTML = result.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
            },
            error: (err) => {
                console.log("Lỗi lấy tổng tiền giỏ hàng");
            }
        })
    }
}

function AddToCart(productId, soLuong, type) {
    //add product to cart
    if (isCustomerLogin == 1) {
        $.ajax({
            url: "/User/AddToCart",
            type: "POST",
            data: { productId, soLuong, type },
            success: (result) => {
                alert(result);
                LoadCart_Layout();
                LoadCartTable();
            },
            error: (err) => {
                alert("Lỗi cập nhật giỏ hàng");
            }
        })
    } else {
        $("#toggle-signin-modal").click();
    }
}

function RemoveFromCart(id) {
    //add product to cart
    if (isCustomerLogin == 1) {
        $.ajax({
            url: "/User/RemoveFromCart",
            type: "POST",
            data: { id },
            success: (result) => {
                console.log(result);
                LoadCart_Layout();
                LoadCartTable();
            },
            error: (err) => {
                alert("Lỗi xoá sản phẩm khỏi giỏ hàng");
            }
        })
    } else {
        $("#toggle-signin-modal").click();
    }
}