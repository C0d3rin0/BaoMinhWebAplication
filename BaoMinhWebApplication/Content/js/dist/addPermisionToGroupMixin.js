class affiliationModel{
    constructor(affiliation){
        this.Label = affiliation.name;

        this.Id = affiliation.value;

        this.downPermision = [
            
        ];

        this.searchPermision = [

        ]; 
    }
}


var addPermisionToGroupMixin={
    data:function(){
        return{
            affiliations:[],
            selectedAffiliations:[],
            removeAffiliation:{
                label:''
            }
        }   
    },

    mounted:function(){
        $.get({
            url: '/api/Affiliate',
            success: function (data) {
                let object = JSON.parse(data);
                Vue.set(this, 'affiliations', object);
            }.bind(this)
        });
    },

    methods:{
        addAffiliation : function(affiliation){

            if(affiliation==null)
            {
                alert('Chi nhánh trong thêm chi nhánh không được để trống');
                return;
            }

            //Kiểm tra xem tồn tại id
            if(this.editData.affiliationWithPermision.filter(af=>af.Id==affiliation.value).length>0)
            {
                alert('chi nhánh này đã được thêm vào nhóm rồi');
                return;
            }

            //Thêm chi nhánh vào nhóm
            let index = this.editData.affiliationWithPermision.length;
            
            Vue.set(
                this.editData.affiliationWithPermision,
                index,
                new affiliationModel(affiliation));

            $("#addAffiliationModal").modal('hide');
        },

        askForRemoveAffiliation:function(affiliation){
            this.removeAffiliation = affiliation;
            $("#removeAffiliationModal").modal('toggle');
            
        },

        confirmRemoveAffiliation:function(){
            /*delete this.addAffiliationModel.affiliations[
                this.removeAffiliation
            ];*/
        },
    }
}