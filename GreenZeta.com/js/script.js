/* Author:

*/

$(document).ready( function($){

    $().UItoTop({ easingType: 'easeOutQuart' });
    $(".index .royalSlider").royalSlider({
        // options go here
        // as an example, enable keyboard arrows nav
        keyboardNavEnabled: true,
        autoScaleSlider: true,
        autoScaleSliderWidth: 900,
        autoScaleSliderHeight: 400,
        imageScaleMode: 'fill',
        globalCaption: true,
        loop: true,
        autoPlay: {
            // autoplay options go gere
            enabled: true,
            pauseOnHover: true,
            delay: 3000
        }
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
        loop: true,
        numImagesToPreload: 4,
        arrowsNavAutohide: true,
        arrowsNavHideOnTouch: true,
        keyboardNavEnabled: true,
        globalCaption: true,
    });

    $('#hga').mouseenter(HeadLeft).mouseleave(HeadReset).bind('touchstart', HeadLeft).bind('touchend', HeadReset);

    $('#hgb').mouseenter(HeadRight).mouseleave(HeadReset).bind('touchstart', HeadRight).bind('touchend', HeadReset);

    $('#btn_home').click(
        function(){
            $('#menu').toggle(); 
            return false;
        }
    );
    
    // Set up the news feed
    $(".newsSlider").facebookfeed(
	{
		id:'102352989996', 
		access_token:'AAADZBCZBwUUGABACz2ZBd3s6SQQW2hnMJhb764dkjvfGA8ewZAODGyI6sNzFKev6sDMZB7MX0EzkBzEQRwDIb5n3c4bCg22bpOXrfjx7u1wZDZD',
		query:{limit:6}
	},
	function(){
		$(".index .newsSlider").royalSlider({
	        // options go here
	        // as an example, enable keyboard arrows nav
	        keyboardNavEnabled: true,
	        autoScaleSlider: true,
	        arrowsNavHideOnTouch: true,
	        autoScaleSliderWidth: $('#news li').width(),
       		autoScaleSliderHeight: ($('#news li').height()+30),
	        imageScaleMode: 'fill',
	        loop: true,
	    });
	});
	
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