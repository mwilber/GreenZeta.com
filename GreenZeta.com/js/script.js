/* Author:

*/

$(document).ready( function($){

    $().UItoTop({ easingType: 'easeOutQuart' });
    $(".index .royalSlider").royalSlider({
        // options go here
        // as an example, enable keyboard arrows nav
        keyboardNavEnabled: true,
        autoScaleSlider: true,
        autoScaleSliderWidth: 1200,
        autoScaleSliderHeight: 400,
        imageScaleMode: 'fill',
        globalCaption: true,
        loopRewind: false,
        autoPlay: {
            // autoplay options go gere
            enabled: false,
            pauseOnHover: true,
            delay: 3000
        }
    });
    $(".index .newsSlider").royalSlider({
        // options go here
        // as an example, enable keyboard arrows nav
        keyboardNavEnabled: true,
        autoScaleSlider: true,
        autoScaleSliderWidth: 210,
        autoScaleSliderHeight: 190,
        imageScaleMode: 'fill'
    });
    $('#gallery-1').royalSlider({
        fullscreen: {
            enabled: true,
            nativeFS: true
        },
        controlNavigation: 'thumbnails',
        autoScaleSlider: true,
        autoScaleSliderWidth: 960,
        autoScaleSliderHeight: 850,
        loop: false,
        numImagesToPreload: 4,
        arrowsNavAutohide: true,
        arrowsNavHideOnTouch: true,
        keyboardNavEnabled: true
    });

    $('#hga').mouseenter(HeadLeft).mouseleave(HeadReset).bind('touchstart', HeadLeft).bind('touchend', HeadReset);

    $('#hgb').mouseenter(HeadRight).mouseleave(HeadReset).bind('touchstart', HeadRight).bind('touchend', HeadReset);
	
} );

function HeadReset() {
    $('#header #stars').css('backgroundPosition', '-50px');
    $('#header #grass').css('backgroundPosition', '-50px');
    $('#header #logo').css('backgroundPosition', '-50px');
    $('#header #hga').css('backgroundPosition', '-20px');
    $('#header #hgb').css('backgroundPosition', '-150px');
}

function HeadLeft() {
    $('#header #stars').css('backgroundPosition', '-40px');
    $('#header #grass').css('backgroundPosition', '-30px');
    $('#header #logo').css('backgroundPosition', '-30px');
    $('#header #hga').css('backgroundPosition', '-40px');
    $('#header #hgb').css('backgroundPosition', '-170px');
}

function HeadRight() {
    $('#header #stars').css('backgroundPosition', '-60px');
    $('#header #grass').css('backgroundPosition', '-70px');
    $('#header #logo').css('backgroundPosition', '-70px');
    $('#header #hga').css('backgroundPosition', '0px');
    $('#header #hgb').css('backgroundPosition', '-130px');
}