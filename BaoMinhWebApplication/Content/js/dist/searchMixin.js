var GetPaginationType = Object.freeze({
    "Next": 0,
    "Prev": 1
})

function checkIfSameClass(plainObj,classFunc){
    plainObj.__proto__ = classFunc.__proto__;
    return plainObj instanceof classFunc;
}


var gridSearchMixin = {
    data: {
        tempFilterViewModel: {},
        sendFilterViewModel: {}
    },

    mounted: function () {
        bus.$on('CapNhatBoLoc', (FilterViewModel) => {
            this.tempFilterViewModel = FilterViewModel;
            this.getDataMixin()
        });
    },

    methods: {
        getDataMixin: function (_GetPaginationType) {
            
            this.sendFilterViewModel = {
                'numItemsPerPage': this.ViewModel.numItemsPerPage,
                'GetPaginationType': _GetPaginationType,
            };
            
            if (_GetPaginationType != null) {
                if (_GetPaginationType == GetPaginationType.Next)
                    this.sendFilterViewModel.keyBoundary = this.ViewModel.keyNextBoundary;
                else if (_GetPaginationType == GetPaginationType.Back)
                    this.sendFilterViewModel.keyBoundary = this.ViewModel.keyPrevBoundary;
            } else {
                this.sendFilterViewModel.GetPaginationType = GetPaginationType.Next;
                this.sendFilterViewModel.keyBoundary = '';
            }
            

            this.prepareSendFilterViewModel();

            this.ViewModel.getData(this.getUrl, this.sendFilterViewModel);
        },
    },

    watch: {
        numItemsPerPage: function (oldValue, newValue) {
            let KhoangChenh = newValue - oldValue;
            if (KhoangChenh < 0) // Tăng
            {
                this.ViewModel.isShowModal = true;
                //Get data
                let data = this.ViewModel.getParsedData(urlSeachNext, {
                    'numItemsPerPage': Math.abs(KhoangChenh),
                    'keyNextBoundary': this.ViewModel.keyNextBoundary,
                    //Bỏ filter model JSON.stringtify vô đây
                }, function (data) {

                    this.ViewModel.data = this.ViewModel.data.concat(data.data);
                    this.ViewModel.isLastPage = data.isLastPage;
                }.bind(this));


            } else // Giảm
            {
                //Cắt bớt
                for (let i = 0; i < KhoangChenh; i++)
                    this.ViewModel.data.pop();

                //Cập nhật isLast
                if (this.ViewModel.isLastPage && this.ViewModel.data) // Nếu trước đó đã có dữ liệu
                {
                    this.ViewModel.isLastPage = false;
                    this.ViewModel.keyNextBoundary = this.ViewModel.data[this.ViewModel.data.length - 1]["id"];
                }
            }
        }
    }

}