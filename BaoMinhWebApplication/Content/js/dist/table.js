class SearchViewModel {
    constructor() {
        this.data = [];
        this.isEmpty = true;
        this.isFirstPage = null;
        this.isLastPage = null;

        this.errorMessage = null;
        this.keyNextBoundary = null;
        this.keyPrevBoundary = null;
        this.isShowModal = false;
        this.numItemsPerPage = 10;
    }

    getData(url, data, isPost) {
        this.getParsedData(url, data, function (data) {
            //Load data
            Object.assign(this, data);
        }.bind(this),isPost)
    }

    getParsedData(url,data,sucess,isPost)
    {
        
        //Parse query
        this.isShowModal = true;

        //Load dữ liệu từ ajax
        var self = this;

        if(!isPost)
        $.get({
            url: url,
            data: data,
            success: function (json) { // Load dữ liệu JSON thành công
                let object = JSON.parse(json);
                sucess(object);
            }

        }).done(function () {
            //Tắt model
            self.isShowModal = false;
        })
        else
        $.post({
            url: url,
            data: data,
            success: function (json) { // Load dữ liệu JSON thành công
                let object = JSON.parse(json);
                sucess(object);
            }

        }).done(function () {
            //Tắt model
            self.isShowModal = false;
        })
    }
}


Vue.component('tableheader', {
    template:
`<tr>
    <th v-if="isshowaction==true">
        Hành động
    </th>

    <th v-for="column in columns">
        {{column}}
    </th>
</tr>`,

    data: function () {
        return {

        };
    },

    props: ['columns', 'isshowaction']
});

Vue.component('datatable-pagination', {
    template:
`<div class="ml-auto">
   
    <button class ="btn btn-white" v-on:click="getPrev()" :disabled="isNextPageDisable">
        <i class ="fas fa-chevron-left"></i>
    </button>
    <button class ="btn btn-white" :disabled="isPrevPageDisable" v-on:click="getNext()">
        <i class ="fas fa-chevron-right"></i>
    </button>
</div>`
    ,

    data: function () {
        return {

        };
    },

    computed: {
        isNextPageDisable:function(){
            var s = this.isFirstPage.toString();
            return s=='true'?true:false;
        },

        isPrevPageDisable: function () {
            var s = this.isLastPage.toString();
            return s=='true'?true:false;
        }
    },

    props: ['is-first-page', 'is-last-page'],

    methods: {
        getNext:function(){
            this.$emit('emit-get-next')
        },

        getPrev:function(){
            this.$emit('emit-get-prev')
        }
    }
});

Vue.component('datatable', {
    template: `
<table class ="table table-bordered table-hover table-row-filter table-click" v-if="isshow==true">

    <tr is="tableheader" :columns="columns" >
    </tr>

    <slot>
    </slot>

    <tr is="tableheader" :columns="columns"></tr>
</table>`
    ,

    props: ['columns', 'isshow', 'isshowaction']
})