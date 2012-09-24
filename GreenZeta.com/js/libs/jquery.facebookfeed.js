/*
 * jQuery FacebookFeed Plugin
 * Requires jQuery 1.4.2
 * Requires jQuery Templates Plugin 1.0.0pre
 * Author Vladimir Shugaev <vladimir.shugaev@junvo.com>
 * Copyright Vladimir Shugaev <vladimir.shugaev@junvo.com>
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 */
(function($){
    $.fn.facebookfeed=function(options, callbackFnk){
		var settings={
			id: '145975662131224', //id of the facebook entity
			template: '<li class="post rsContent"><img class="postimg" src="${picture}"/><p class="postlink"><a href="${link}" target="_blank">${name}</a></p><p class="postmessage">${message}</p><div style="clear:both;"></div></li>',
			query: {},
			access_token: ''
		};
		if (options)
			$.extend(settings, options);
		var container=this;
		var requestURL='https://graph.facebook.com/'+settings.id+'/feed?access_token='+settings.access_token+'&'+$.param(settings.query)+'&callback=?'; //calback=? is required to get JSONP behaviour
		var template=$.template(null, settings.template);

		$.getJSON(requestURL, function(json){
			var messages=$.tmpl(template, json.data).appendTo(container);
			// now call a callback function
		    if(typeof callbackFnk == 'function'){
				callbackFnk.call();
		    }
		});
		return this;
	};
})(jQuery);