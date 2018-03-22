var searchGroupByNameMixin = {

    data:function(){
        return{
            Groups:[]
        }
    },

    methods:{
        GroupNameOnSearch: function (text, loading) {
            onSearchConvention.call(
                this,
                {'name':text},
                loading,
                '/api/Group',
                'Groups');
        }
    }


}

