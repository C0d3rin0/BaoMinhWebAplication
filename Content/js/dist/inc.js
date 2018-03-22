// Vue.component('tree', window.VueTreeselect.Treeselect);
//
Vue.component('group-checkbox',{
    template:
'<div>'+
    '<input type="checkbox" v-model="isRootChecked" ref="root2">'+
    '</input>'+ 
    '&nbsp;<b><slot></slot></b>'+
    '<hr>'+
    '<div class="d-flex" v-if="isRootChecked">'+
        '<div class="checkbox-container col-6"> <p class="mb-3"><b>Risk Type :</b></p>'+
            '<div>'+
            '<input @click="updateViewModel" type="checkbox" @change="toggleAllRisk" ref="root">'+
            '</input>'+ 
            '&nbsp;<label>Chọn tất cả</label>'+
            '</div>'+
            '<div v-for="RSKTYP in UniqueRSKTYPs">'+
                '<input @click="updateViewModel" type="checkbox" :value="RSKTYP" v-model="value.RSKTYP"></input> <label>{{RSKTYP}}</label>'+
            '</div>'+
        '</div>'+

        '<div class="checkbox-container col-6"> <p class="mb-3"><b>Premium Class :</b></p>'+
            '<div>'+
            '<input @click="updateViewModel" type="checkbox" @change="toggleAllPrem" ref="root">'+
            '</input>'+ 
            '&nbsp;<label>Chọn tất cả</label>'+
            '</div>'+
            '<div v-for="_PREMCL in PREMCLs">'+
                '<input @click="updateViewModel" type="checkbox" :value="_PREMCL" v-model="value.PREMCL"></input> <label>{{_PREMCL}}</label>'+
            '</div>'+
        '</div>'+
    '</div>'+
'</div>'

    ,data:function(){
        return {
            isRootChecked:false,
            value:{
                RSKTYP :[],
                PREMCL : []
            }
        }
    },

    methods: {
        toggleAllRisk:function(e){
            if(e.target.checked)
                this.value.RSKTYP = this.UniqueRSKTYPs;
            else 
                this.value.RSKTYP = [];
        },

        toggleAllPrem:function(e){
            if(e.target.checked)
                this.value.PREMCL = this.PREMCLs;
            else 
                this.value.PREMCL = [];
        },

        updateViewModel:function(){
            this.$emit('input',this.value);
        }
    },
    

    computed:{
        UniqueRSKTYPs:function(){
            if(!this.$props.data) return []
            
            //else
            let RSKTYPs = this.$props.data.map(elem=>elem.RSKTYP);
            let UniqueRSKTYPs = new Set(RSKTYPs);
            return Array.from(UniqueRSKTYPs);
        },

        PREMCLs:function(){
            if(!this.$props.data) return []
            return this.$props.data.map(elem=>elem.PREMCL);
        }
    },

    props:['data']
});

//Parse query
//OOP 
let bus = new Vue({

});

class IncomeReportDataTableViewModel extends SearchViewModel {
    constructor() {
        super();
        this.detailsData = [
            []
        ];
        this.arrIsShowDetail = [];
        this.detailsData = [];
    }



    parseJSON(json) { // Inheritance
        super.parseJSON(json);

        //Khác nhau
        this.detailsData = [
            []
        ];

    }
}

class IncomeReportFilterViewModel {
    constructor() {
        this.DanhSachChiNhanh = [];
        this.DanhSachPhongBan = [];
        this.HoTenKhachHang = '';
        this.DanhSachMaDaiLy = [];
        this.DanhSachLoaiDaiLy = [];
        this.NgayHieuLucTu = '';
        this.NgayHieuLucDen = '';
        this.DanhSachNghiepVu = null;
    }
}

var filterDataTable = new Vue({
    el: "#filterDataTable",
    data: {
        ViewModel: new IncomeReportFilterViewModel(),
        initData: {},
        DanhSachPhongBan: [],
        DanhSachHoTen: [],
        DanhSachMaDaiLy: [],
        DanhSachLoaiDaiLy: [],

        DanhSachNghiepVuXe:null,
        DanhSachNghiepVuKT:null,
        DanhSachNghiepVuHH : null,

        options: null
    },
    methods: {
        // PhongBanOnSearch: function (text, loading) {
        //     onSearchConvention.call(
        //         this,
        //         text,
        //         loading,
        //         '/IncomeReport/layDanhSachPhongBanTheoTenHoacMa',
        //         'DanhSachPhongBan');
        // },

        // HoTenOnSearch: function (text, loading) {
        //     onSearchConvention.call(
        //         this,
        //         text,
        //         loading,
        //         '/IncomeReport/layHoTenKhachHang',
        //         'DanhSachHoTen');
        // },

        // MaDaiLyOnSearch: function (text, loading) {
        //     onSearchConvention.call(
        //         this,
        //         text,
        //         loading,
        //         '/IncomeReport/layMaDaiLy',
        //         'DanhSachMaDaiLy');
        // },

        // LoaiDaiLyOnSearch: function (text, loading) {
        //     onSearchConvention.call(
        //         this,
        //         text,
        //         loading,
        //         '/IncomeReport/layLoaiDaiLy',
        //         'DanhSachLoaiDaiLy');
        // },
        
        CapNhatBoLoc: function () {
            bus.$emit("CapNhatBoLoc", this.ViewModel);
        }
    },
    mounted: function () {
        $.post({
            url: '/IncomeReport/Load',
            success: function (data) {
                let object = JSON.parse(data);
                Vue.set(this, 'initData', object);
            }.bind(this)
        });
    },

    // created: function(){
    //     $.post({
    //         url: '/IncomeReport/layNghiepVu',
    //         success: function (data) {
    //             let object = JSON.parse(data);
    //             Vue.set(this, 'options', object);
    //             this.$refs.tree.initialize(this.options);
    //         }.bind(this)
    //     });

        
    // }
})





//Init incomereport datatable
var dataTable = new Vue({
    el: "#dataTable",
    data: {
        ViewModel: new IncomeReportDataTableViewModel(),
        FilterViewModel: null
    },
    methods: {
        toggleArrIsShowDetail: function (index, RLDGACCT) {
            if (!this.ViewModel.data[index])
                return;

            //Toggle
            Vue.set(this.ViewModel.arrIsShowDetail, index, !this.ViewModel.arrIsShowDetail[index]);

            //lấy dữ liệu nếu chưa 
            var curDetailsData = this.ViewModel.detailsData[index];

            if (!curDetailsData || !curDetailsData.length) {
                var self = this;
                $.post({
                    url: '/IncomeReport/ViewDetails',
                    data: {
                        'RLDGACCT': '' + RLDGACCT
                    },
                    success: function (data) {
                        var curDetailsData = self.ViewModel.detailsData[index];
                        Vue.set(self.ViewModel.detailsData, index, JSON.parse(data));
                    }
                });
            }

        },

        getNext: function () {
            this.ViewModel.getData('/IncomeReport/RemoteSearch', {
                'keyNextBoundary': this.ViewModel.keyNextBoundary,
                'numItemsPerPage': this.ViewModel.numItemsPerPage,
            }, true);
        },

        getPrev: function () {
            this.ViewModel.getData('/IncomeReport/RemoteSearch', {
                'keyPrevBoundary': this.ViewModel.keyPrevBoundary,
                'numItemsPerPage': this.ViewModel.numItemsPerPage,
            }, true);
        },


    },
    computed: {
        getAllColumnsName: function () {
            if (!this.ViewModel.isEmpty)
                return Object.keys(this.ViewModel.data[0]);
            else
                return [];
        },

        numItemsPerPage: function () {
            return this.ViewModel.numItemsPerPage;
        }
    },
    mounted: function () {
        // this.ViewModel.isShowModal = true;
        // this.ViewModel.getData('/IncomeReport/RemoteSearch', {
        //     'numItemsPerPage': this.ViewModel.numItemsPerPage,
        //     //Bỏ filter model JSON.stringtify vô đây
        // });

        bus.$on('CapNhatBoLoc', (FilterViewModel) => {
            this.isShowModal = true;
            this.FilterViewModel = FilterViewModel;
            this.ViewModel.getData('/IncomeReport/RemoteSearch', {
                'numItemsPerPage': this.ViewModel.numItemsPerPage,
                'SearchViewModel': this.FilterViewModel
            }, true);
        });
    },
    watch: {
        numItemsPerPage: function (oldValue, newValue) {
            let KhoangChenh = newValue - oldValue;
            if (KhoangChenh < 0) // Tăng
            {
                this.ViewModel.isShowModal = true;
                //Get data
                let data = this.ViewModel.getParsedData('/IncomeReport/RemoteSearch', {
                    'numItemsPerPage': Math.abs(KhoangChenh),
                    'keyNextBoundary': this.ViewModel.keyNextBoundary,
                    //Bỏ filter model JSON.stringtify vô đây
                }, function (data) {

                    this.ViewModel.data = this.ViewModel.data.concat(data.data);
                    this.ViewModel.isLastPage = data.isLastPage;
                }.bind(this));


            } 
            else // Giảm
            {
                //Cắt bớt
                for (let i = 0; i < KhoangChenh; i++)
                    this.ViewModel.data.pop();

                //Cập nhật isLast
                if (this.ViewModel.isLastPage && this.ViewModel.data) // Nếu trước đó đã có dữ liệu
                {
                    this.ViewModel.isLastPage = false;
                    this.ViewModel.keyNextBoundary = this.ViewModel.data[this.ViewModel.data.length - 1]["MÃ ĐƠN"];
                }
            }
        }
    }
});