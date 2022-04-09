    var str = "";
    function DisplayAllProducts() {
        var str = '<table class="table"><thead><tr><td>Mã sản phẩm</td><td>Tên sản phẩm</td><td>Giới thiệu sản phẩm</td></tr></thead ><tbody>';
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44306/api/sanpham/GetAllSP',
            dataType: 'json',
            success: function (data) {
                $.each(data, function (key, val) {
                    str += '<tr><td>' + val.MATACGIA + '</td><td>' + val.TENTACGIA + '</td></tr>';
                });
                str += '</tbody></table>';
                $('#DisplayHere').html(str);
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    }
