Vue.component('v-select',VueSelect.VueSelect);

let createUserViewModel = class{
    constructor(){
        this.HoTen="",
        this.Email="",
        this.MatKhau="",
        this.NhapLaiMatKhau="",
        this.MaNhom = []
    }
}

let app = new Vue({
    el:"#app",
    data:{
        Groups:[],
        SelectedGroups:[],
        ViewModel:new createUserViewModel(),
        ResultViewModel: new ResultViewModel(),
        domainName: 'tài khoản'
    },

    methods: {
        createUser:function(){
            //Nếu đúng submit form
            this.ViewModel.MaNhom = 
                this.Groups.map(el=>el.id);

            onCreateConvention.call(
                this,
                this.ViewModel,
                '/api/User',
                'ResultViewModel');
        },

        GroupNameOnSearch: function (text, loading) {
            onSearchConvention.call(
                this,
                {'name':text},
                loading,
                '/api/Group',
                'Groups');
        }
    }
})