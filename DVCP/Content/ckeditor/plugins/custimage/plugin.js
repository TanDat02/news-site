CKEDITOR.plugins.add('custimage', {
    icons: 'custimage', init: function (editor) {
        editor.addCommand('custimage', new CKEDITOR.dialogCommand('custimageDialog'));
        editor.ui.addButton('custimage', {
            label: editor.lang.common.image, command: 'custimage', toolbar: 'insert'
        });
        CKEDITOR.dialog.add('custimageDialog', this.path + 'dialogs/custimage.js')
    }
});