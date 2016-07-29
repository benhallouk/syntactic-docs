var syntacticDocs = syntacticDocs || (function () {
    var showBacktoTop = function(element){
        if ($(element).scrollTop() > 50) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    };
    return {
        currentDocument: {},
        cancelChanges: function(){
            location.reload(true);
        },
        saveCurrentDocument: function(){
            $.post( "/home/save/", syntacticDocs.currentDocument,function(data){
                if(data && data.id) location.reload(true);
            });
        },
        init: function(){ 
            hljs.initHighlightingOnLoad();
            $(document).ready(function(){
                $(".content").scroll(function () {                    
                    showBacktoTop(this);
                });            
                $(window).scroll(function(){                    
                    showBacktoTop(this);
                });  
                $('#back-to-top').click(function () {
                    $('#back-to-top').tooltip('hide');
                    $('.content,body').animate({
                        scrollTop: 0
                    }, 800);
                    return false;
                });            
                $('#back-to-top').tooltip('show');
                var markdownEditor = null;
                $("#edit-document-btn").click(function(){        
                    markdownEditor = markdownEditor || new SimpleMDE({ element: $("#markdown-editor")[0] });
                    if(!$("#markdown-view-mode").is(":visible")){                        
                        syntacticDocs.currentDocument.content = markdownEditor.value();
                        $('#save-confirmation').modal('show');                        
                    }        
                    $("#markdown-view-mode").toggle();
                    $("#markdown-edit-mode").toggle();
                });
            });
        }
    };
})();
syntacticDocs.init();