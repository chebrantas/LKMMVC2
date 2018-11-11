CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'forms', groups: ['forms'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'paragraph', groups: ['align', 'list', 'indent', 'blocks', 'bidi', 'paragraph'] },
        '/',
        { name: 'styles', groups: ['styles'] },
        { name: 'links', groups: ['links'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'others', groups: ['others'] },
        { name: 'about', groups: ['about'] }
    ];

    config.removeButtons = 'Print,Save,Templates,Cut,Copy,Paste,Undo,Redo,Find,SelectAll,Language,Flash,PageBreak,Iframe,About';
};
