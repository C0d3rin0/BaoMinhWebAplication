var searchUserByEmailMixin = {
    data:function(){
        return{
            Users:[]
        }
    },

    methods:{
        UserEmailOnSearch: function (text, loading) {
            onSearchConvention.call(
                this,
                {'Email':text},
                loading,
                '/api/User',
                'Users');
        },
    }
}