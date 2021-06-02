$(function(){
	var themecolor=($.cookie('egovthemecolor')||'default');
	$('.linkcolorsite').prop('disabled',true);
	if(themecolor!='default'){$('#'+themecolor).prop('disabled',false);
}$('[data-toggle="changethemcolor"]').each(function(){if($(this).data('color')==themecolor){
	$(this).addClass('active');}})
;$('[data-toggle="mycollapse"]').click(function(e){e.preventDefault();e.stopPropagation();
	$($(this).attr('href')).toggleClass('in');});
$('#toggleearch').click(function(e){e.stopPropagation();});
$(window).on('click',function(){$('#toggleearch').removeClass('in');});
$('#siteformsearch').submit(function(e){var q=trim($('[name="q"]',$(this)).val());
	if(q.length<$(this).data('minlen')||q.length>$(this).data('maxlen')){e.preventDefault();
		$(this).addClass('has-error');}});$('[data-toggle="faqoptab"]').click(function(e){e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent();
			$('.tptabcontent > div',tabarea).hide();
			$('.tptabtitle a',tabarea).removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');});

			$('[data-toggle="newtabslide"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn',tabarea).hide();
			$('[data-toggle="newtabslide"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//newtabslide1
			$('[data-toggle="newtabslide1"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn1',tabarea).hide();
			$('[data-toggle="newtabslide1"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel1',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel1',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel1',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//end newtabslide1
			////newtabslide2
			$('[data-toggle="newtabslide2"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn2',tabarea).hide();
			$('[data-toggle="newtabslide2"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel2',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel2',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel2',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//end newtabslide2
			////newtabslide3
			$('[data-toggle="newtabslide3"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn3',tabarea).hide();
			$('[data-toggle="newtabslide3"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel3',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel3',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel3',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//end newtabslide3
			//////newtabslide4
			$('[data-toggle="newtabslide4"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn4',tabarea).hide();
			$('[data-toggle="newtabslide4"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel4',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel4',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel4',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//end newtabslide4
			////newtabslide5
			$('[data-toggle="newtabslide5"]').click(function(e){
			e.preventDefault();
			var tabarea=$(this).parent().parent().parent().parent().parent().parent();
			$('.newstabhomejcarousel-ctn5',tabarea).hide();
			$('[data-toggle="newtabslide5"]').removeClass('active');
			$($(this).attr('href')).show();$(this).addClass('active');
			$('.newstabhomejcarousel5',$(this).attr('href')).jcarousel('scroll',0);
			$('.newstabhomejcarousel5',$(this).attr('href')).jcarousel('destroy');
			$('.newstabhomejcarousel5',$(this).attr('href')).jcarousel({wrap:'circular',}).jcarouselAutoscroll({interval:5000,target:'+=1',autostart:true});
		}
			);
			//end newtabslide3
		$('[data-toggle="postfsize"]').click(function(e){e.preventDefault();var size=$(this).data('size');if(size==0.8){size=1;}else if(size==1){size=1.2;}else if(size==1.2){size=1.5;}else if(size==1.5){size=2;}else{size=0.8;}$(this).data('size',size);$('.bodytext,.hometext').css("font-size",size+'em');});$('[data-toggle="showhide"]').click(function(e){e.preventDefault();$($(this).data('target')).toggleClass('hidden');});$('[data-toggle="changethemcolor"]').click(function(e){e.preventDefault();var color=$(this).data('color');$.cookie('egovthemecolor',color);$('.linkcolorsite').prop('disabled',true);if(color!='default'){$('#'+color).prop('disabled',false);}$('[data-toggle="changethemcolor"]').removeClass('active');$(this).addClass('active');});});