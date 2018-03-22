class LoginViewModel {
    constructor() {
        this.email = "";
        this.password = "";
    }
}

let app = new Vue({
    el: '#app',

    data: {
        ViewModel: new LoginViewModel(),
        ResultViewModel: new ResultViewModel(),
        isShowModalLoading:false
    },

    methods: {
        login:function(){
            this.isShowModalLoading=true;
            //Gọi API kiểm tra mật khẩu
            $.post({
                url: '/user/login',
                data: {
                    viewModel:this.ViewModel
                },
                success: (data)=> {
                    if(data=="") // login thành công
                        $("#refreshForm").submit();

                    let object = JSON.parse(data);
                    Object.assign(this.ResultViewModel,object)
                }
            }).done(()=>{
                this.isShowModalLoading=false;
            })

            //Nếu đúng submit form
        }
    }
})

