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
        addDocument: function(){
            var title = $('#document-title').val();
            var alias = title.toLowerCase().replace(/ /g,'-').replace(/[^\w-]+/g,'-');
            var addData = {
                parentId: syntacticDocs.currentDocument.id,
                alias: alias,
                title: title
            };
            $.post( "/home/add/", addData,function(data){
                if(data && data.id) location.reload(true);
            });
        },
        saveCurrentDocument: function(){
            $.post( "/home/save/", syntacticDocs.currentDocument,function(data){
                if(data && data.id) location.reload(true);
            });
        },
        deleteCurrentDocument: function(){
            $.post( "/home/delete/", syntacticDocs.currentDocument,function(data){
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
                $(".add-document a").click(function(){
                    $('#add-confirmation').modal('show');
                });
                $("#edit-document-btn").click(function(){        
                    markdownEditor = markdownEditor || new SimpleMDE({ element: $("#markdown-editor")[0] });
                    if(!$("#markdown-view-mode").is(":visible")){                        
                        syntacticDocs.currentDocument.content = markdownEditor.value();
                        $('#save-confirmation').modal('show');                  
                    }        
                    $("#markdown-view-mode").toggle();
                    $("#markdown-edit-mode").toggle();
                });
                $("#delete-document-btn").click(function(){
                    $('#delete-confirmation').modal('show');
                });                
            });
        }
    };
})();
syntacticDocs.init();