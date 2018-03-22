var editRowSearchMixin = {
    data:function(){
        return {

        }
    },
    methods:{
        getData:function(){
            $.get({
                url:this.url,
                success:(json)=>{
                    var object = JSON.parse(json);
                    this.editData = object;
                }
            })
        },

        updateData:function(){
            $.ajax({
                data:this.editData,
                type:'put',
                url:this.url,
                success:(json)=>{
                    var object = JSON.parse(json);

                    if(object.header==null){
                        this.CurrentUIMode='View';
                        alert('Cập nhật dữ liệu thành công');
                        
                        /* Cập nhật lại v-model */


                        this.$emit('input', object);

                        return;
                    }

                    
                    

                    var object = JSON.parse(json);
                    this.ResultViewModel = object;
                }
            })
        },

        deleteData:function(){
            $.ajax({
                url:this.url,
                data:{'id':this.value.Id},
                type:'delete',
                success:(json)=>{//json)=>{
                    alert(`Ngắt kích hoạt ${this.domainName} thành công`);
                    var object = JSON.parse(json);
                    this.$emit('input', object);
                    
                    if(this.value.Id==this.Id)
                        $("#logoffForm").submit(); 
                }
            })
        },

        undeleteData:function(){
            $.post({
                url:'/'+this.domainUrl+'/Undelete',
                data:{'id':this.value.Id},
                success:(json)=>{
                    alert(`Kích hoạt ${this.domainName} thành công`);
                    var object = JSON.parse(json);
                    this.$emit('input', object);
                }
            })
        }
    }
}