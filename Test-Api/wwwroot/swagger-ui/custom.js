(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://www.welldex-nte.com.mx/";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "WELLDEX Test API";
            logo[0].children[0].src = "../swagger-ui/wdxlogo.png";
        });
    });
})();