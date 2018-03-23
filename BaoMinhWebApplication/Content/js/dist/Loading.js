Vue.component('loading', { template:
`<div
class ="mask p-0 m-0 d-flex justify-content-center align-items-center flex-column text-white"
id="loading"
v-if="isshow==true">
    <div class="text-center pb-4">
        <span>{{header}}</span> <br />
        {{message}}
    </div>
    <div>
        <i class="fas fa-4x fa-spin fa-cog"></i>
    </div>
</div>`,

    data: function () {
        return {

        };
    },

    props: ['isshow', 'header', 'message']
});


Vue.component('inline-modal', {
    template:
`<div class="info-box" v-if="isshow==false">
    <div class="p-2 bg-info">
        <i class="fas fa-info-circle fa-fw"></i>
        {{header}}
    </div>
    <div class="p-2">
        {{message}}
    </div>
</div>`,

    data: function () {
        return {

        };
    },

    props: ['isshow', 'header', 'message']
});

class ResultViewModel  {
    constructor(){
        this.header='',
        this.message='',
        this.isShowModal=false
    }
}