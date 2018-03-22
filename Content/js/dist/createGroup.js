Vue.component('v-select',VueSelect.VueSelect);

class affiliation{
    constructor(affiliation){
        this.affiliation = affiliation;

        this.id = affiliation.value;

        this.downPermision = [
            
        ];

        this.searchPermision = [

        ]; 
    }
}

class createGroupViewModel{
    constructor(){
       this.name="",
       this.usersId =[],      
       this.affiliationsWithPermision=[]
    }
}

class addAffiliationModel{
    constructor(){
        this.affiliations = [],
        this.selectedAffiliation = null
    }
}

let app = new Vue({
    el:"#app",
    data:{
        Users:[],
        SelectedUsers:[],
        affiliationsWithPermision:{},
        ViewModel : new createGroupViewModel(),
        ResultViewModel: new ResultViewModel(),
        addAffiliationModel : new addAffiliationModel(),
        removeAffiliation:{
            label:""
        },
        domainName: 'nhóm tài khoản'
    },

    watch:{
        SelectedUsers:function(arr){
            this.ViewModel.usersId = arr.map(val=>val.Id);
        }
    },

    mounted:function(){
        $.get({
            url: '/api/Affiliate',
            success: function (data) {
                let object = JSON.parse(data);
                Vue.set(this.addAffiliationModel, 'affiliations', object);
            }.bind(this)
        });
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

        createGroup:function(){
            this.ViewModel.affiliationsWithPermision = 
                Object.values(this.affiliationsWithPermision);

            onCreateConvention.call(
                this,
                this.ViewModel,
                '/api/Group',
                'ResultViewModel');
        },

        addAffiliationToUser: function(id){

            if(id==null)
            {
                alert('Chi nhánh trong thêm chi nhánh không được để trống');
                return;
            }

            //Kiểm tra xem tồn tại id
            if(this.affiliationsWithPermision[id])
            {
                alert('chi nhánh này đã được thêm vào nhóm rồi');
                return;
            }

            //Thêm chi nhánh vào nhóm
            Vue.set(this.affiliationsWithPermision,id,new affiliation(id));
            $("#addAffiliationModal").modal('hide');
        },

        askForRemoveAffiliation:function(affiliation){
            this.removeAffiliation = affiliation;
            $("#removeAffiliationModal").modal('toggle');
            
        },

        confirmRemoveAffiliation:function(){
            delete this.addAffiliationModel.affiliations[
                this.removeAffiliation
            ];
        },
    }
})

