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
    data: {
        SelectedUsers: null,
        Users: [],
    },
    methods: {
        EmailOnSearch: function (text, loading) {
            onSearchConvention.call(
                this, {
                    'Email': text
                },
                loading,
                '/api/User',
                'Users');
        },

        CapNhatBoLoc: function () {
            bus.$emit("CapNhatBoLoc", this.SelectedUsers);
        }
    }
})

//Init SearchUser datatable
var dataTable = new Vue({
    el: "#dataTable",
    mixins: [gridSearchMixin],
    data: {
        ViewModel: new SearchUserDataTableViewModel(),
        getUrl: '/api/User'
    },

    methods: {
        prepareSendFilterViewModel:function(){
            if(this.tempFilterViewModel)
                this.sendFilterViewModel.Id  = this.tempFilterViewModel.Id;
        }
    }
});

