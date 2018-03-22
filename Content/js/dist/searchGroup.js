//Parse query
//OOP 
let bus = new Vue({

});

class SearchUserDataTableViewModel extends SearchViewModel {
    constructor() {
        super();
        // this.detailsData = [[]];
        // this.arrIsShowDetail = [];
        // this.detailsData = [];
    }



    parseJSON(json) { // Inheritance
        super.parseJSON(json);

        //Khác nhau
        this.detailsData = [
            []
        ];

    }
}

var filterDataTable = new Vue({
    el: "#filterDataTable",
    mixins:[searchGroupByNameMixin],
    data: {
        SelectedGroups: null,
    },
    methods: {
        CapNhatBoLoc: function () {
            bus.$emit("CapNhatBoLoc", this.SelectedGroups);
        }
    }
})

//Init SearchUser datatable
var dataTable = new Vue({
    el: "#dataTable",
    mixins: [gridSearchMixin],
    data: {
        ViewModel: new SearchUserDataTableViewModel(),
        getUrl: '/api/Group'
    },

    methods: {
        prepareSendFilterViewModel:function(){
            if(this.tempFilterViewModel)
                this.sendFilterViewModel.Id  = this.tempFilterViewModel.Id;
        }
    }
});

