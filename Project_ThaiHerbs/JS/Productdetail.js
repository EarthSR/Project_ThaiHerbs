<script type="text/javascript">
    function decreaseQuantity() {
        var quantityInput = document.getElementById('<%= quantityInput.ClientID %>');
        if (parseInt(quantityInput.value) > 1) {
        quantityInput.value = parseInt(quantityInput.value) - 1;
        }
    return false; // เพื่อป้องกันการโพสต์กลับเซิร์ฟเวอร์
    }

    function increaseQuantity() {
        var quantityInput = document.getElementById('<%= quantityInput.ClientID %>');
    if (parseInt(quantityInput.value) < 100) {
        quantityInput.value = parseInt(quantityInput.value) + 1;
        }
    return false; // เพื่อป้องกันการโพสต์กลับเซิร์ฟเวอร์
    }
</script>