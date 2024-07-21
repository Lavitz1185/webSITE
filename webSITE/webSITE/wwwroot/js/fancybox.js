
$(document).ready(function () {
    $("[data-fancybox]").fancybox({
        Image: {
            initialSize: "fit",
        },
        Thumbs: {
            showOnStart: true,
            position: "bottom"
        },
        Toolbar: {
            display: {
                left: ["infobar"],
                middle: [
                    "zoomIn",
                    "zoomOut",
                    "toggle1to1",
                    "rotateCCW",
                    "rotateCW",
                    "flipX",
                    "flipY"
                ],
                right: ["slideshow", "thumbs", "close"]
            }
        }
    });
});