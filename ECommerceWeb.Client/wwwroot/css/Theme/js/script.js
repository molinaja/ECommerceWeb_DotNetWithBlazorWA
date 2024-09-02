let containerIsotope = "";

var initSwiper = function () {

    var swiper = new Swiper(".main-swiper", {
        speed: 500,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });

    var bestselling_swiper = new Swiper(".bestselling-swiper", {
        slidesPerView: 4,
        spaceBetween: 30,
        speed: 500,
        breakpoints: {
            0: {
                slidesPerView: 1,
            },
            768: {
                slidesPerView: 3,
            },
            991: {
                slidesPerView: 4,
            },
        }
    });

    var testimonial_swiper = new Swiper(".testimonial-swiper", {
        slidesPerView: 1,
        speed: 500,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });

    var products_swiper = new Swiper(".products-carousel", {
        slidesPerView: 4,
        spaceBetween: 30,
        speed: 500,
        breakpoints: {
            0: {
                slidesPerView: 1,
            },
            768: {
                slidesPerView: 3,
            },
            991: {
                slidesPerView: 4,
            },

        }
    });

}

function initializeIsotope() {

    setTimeout(function () {
        // Initialize Isotope
        var $container = $('.isotope-container').isotope({
            // options
            itemSelector: '.item',
            layoutMode: 'masonry'
        });

        containerIsotope = $container;
    }, 500);

}

function filterIsotope(filterValue) {


    if (containerIsotope) {
        if (filterValue === ".ALL") {
            containerIsotope.isotope({ filter: '*' });
        } else {
            containerIsotope.isotope({ filter: filterValue });

        }

    }

}

function initializeScripts() {

    initSwiper();
    initializeIsotope()

    // product single page
    var thumb_slider = new Swiper(".product-thumbnail-slider", {
        spaceBetween: 8,
        slidesPerView: 3,
        freeMode: true,
        watchSlidesProgress: true,
    });

    var large_slider = new Swiper(".product-large-slider", {
        spaceBetween: 10,
        slidesPerView: 1,
        effect: 'fade',
        thumbs: {
            swiper: thumb_slider,
        },
    });

}