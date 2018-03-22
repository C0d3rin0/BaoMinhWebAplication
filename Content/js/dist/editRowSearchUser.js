Vue.component('edit-row', {
    mixins: [editRowSearchMixin,searchGroupByNameMixin],
    template: `<tr>
    <template v-if="CurrentUIMode=='View'">
        <td>
            <a href="javascript:void(0);" class="mr-3" @click="deleteData" v-if="value.State==true">
                <i class="fas fa-trash"></i> Ngắt kích hoạt
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="undeleteData" v-if="value.State==false">
                <i class="fas fa-trash"></i> kích hoạt
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="setAdmin" v-if="value.LaAdmin==false">
                <i class="fas fa-trash"></i> Set admin
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="unsetAdmin" v-if="value.LaAdmin==true">
                <i class="fas fa-trash"></i> Unset admin
            </a>
            <a href="javascript:void(0);" class="mr-3" @click="changeEditMode('Edit')">
                <i class="fas fa-edit"></i> Chỉnh sửa thông tin
            </a>
            <a href="javascript:void(0);" @click="changeEditMode('changePassword')">
                <i class="fas fa-lock"></i> Đổi mật khẩu
            </a>
        </td>
        <td v-for="(val,key) in value" v-if="key!='Id' && key != 'State' && key != 'LaAdmin'">
            <span>{{val}}</span>
        </td>
        
    </template>
    <td colspan="3" class="px-0 pb-0" v-if="CurrentUIMode=='Edit'">
        <div class=" m-0 mb-2 px-0">        
            <div class=" px-4 py-2" v-if="editData!=null">
                <ul class="list-group mb-4">
                    <li class="list-group-item heading text-muted">
                        <h1 class="">
                            <i class="fas fa-keyboard"></i>
                            Cập nhật thông tin tài&nbsp;khoản {{value.Email}}
                        </h1>
                    </li>

                    <li class="list-group-item pt-4 d-flex flex-wrap">
                        <div class="col-12 my-2 px-0 mx-0">
                            <inline-modal :header="ResultViewModel.header" :message="ResultViewModel.message" :isshow="!ResultViewModel.isShowModal==true">
                            </inline-modal>
                        </div>

                        <div class="col-6 form-group pl-0">
                            <label for="form2">Họ tên</label>
                            <input type="text" class="form-control px-0" v-model="editData.Fullname">
                        </div>

                        <div class="col-6 form-group pl-0">
                            <label for="form2">Email</label>
                            <input type="text" class="form-control px-0" v-model="editData.Username">
                        </div>
                    </li>
                </ul>
                <ul class="list-group mb-4">
                    <li class="list-group-item heading text-muted">
                        <h1 class="d">
                            <i class="fas fa-search-plus"></i>
                            Chọn nhóm người dùng
                            <br>
                            <span class="mb-0">Click để tìm và thêm nhóm người dùng</span>
                        </h1>
                    </li>


                    <li class="list-group-item py-4">
                        <div>
                            <v-select multiple v-model="editData.SelectedGroups"
                                        :options="Groups"
                                        v-on:search="GroupNameOnSearch">
                                <span slot="no-options">
                                    Không tìm thấy nhóm tài khoản nào
                                </span>
                            </v-select>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        
        

        <div class="list-group-item d-flex border-x-0 mt-2">
            <button class="btn btn-gray ml-auto mb-2 ml-2" type="button" v-on:click="CurrentUIMode='View'">
                <i class="fas fa-window-close ml-1"></i>
                Hủy
            </button>

            <button class="btn btn-white mb-2" type="button" v-on:click="updateDataModified">
                <i class="fas fa-paper-plane ml-1"></i>
                Sửa thông tin tài khoản
            </button>
        </div>

    </td>

    <td colspan="3" class="px-0 py-0" v-if="CurrentUIMode=='changePassword'">
        <div class="list-group-item d-flex border-x-0 mt-0 flex-wrap">
            <inline-modal class="col-12 px-0" :header="ResultViewModel.header"
                :message="ResultViewModel.message"
                :isshow="!ResultViewModel.isShowModal==true">
            </inline-modal>

            <ul class="list-group mb-4 col-12">
                <li class="list-group-item heading text-muted">
                    <h1 class="">
                        <i class="fas fa-keyboard"></i>
                        Nhập mật khẩu mới cho tài &nbsp;khoản {{value.Email}}
                    </h1>
                </li>

                <li class="list-group-item pt-4 d-flex flex-wrap">
                    <div class="col-12 form-group pl-0">
                        <label for="form2">Mật khẩu mới</label>
                        <input type="password" class="form-control px-0" v-model="newPassword">
                    </div>
                </li>
            </ul>
        </div>

        <div class="list-group-item d-flex border-x-0">
            <button class="btn btn-gray mr-3 m-0 ml-auto mb-2" type="button" v-on:click="CurrentUIMode='View'">
                <i class="fas fa-window-close ml-1"></i>
                Hủy
            </button>

            <button class="btn btn-white m-0 mb-2" type="button" v-on:click="changePassword">
                <i class="fas fa-paper-plane ml-1"></i>
                Đổi mật khẩu
            </button>
        </div>
    </td>
</tr>`,

    props: ['value'],

    data: function () {
        return {
            newPassword:'',
            CurrentUIMode: 'View',
            editData: null,
            url: '/api/User/' + this.value.Id,
            Id:null,
            ResultViewModel: new ResultViewModel(),
            domainName: 'tài khoản',
            domainUrl : 'User'
        }
    },

    mounted:function(){
        $.post({
            url:'/User/getCurrentUserId',
            data:null,
            success:(json)=>{//json)=>{
                this.Id=json;
            }
        })
    },

    methods: {
        changeEditMode: function (UIMode) {
            this.ResultViewModel = new ResultViewModel();
            this.CurrentUIMode = UIMode;

            switch (this.CurrentUIMode) {
                case 'Edit':
                    this.getData();
                default:
                    return;
            }
        },

        changePassword: function(){
            $.get({
                url:'/User/changePassword/'+this.value.Id,
                data:{
                    'Password' : this.newPassword 
                },
                success:(json)=>{
                    

                    if(json==''){
                        this.CurrentUIMode='View';
                        alert('Đổi mật khẩu thành công');
                        return;
                    }

                    var object = JSON.parse(json);
                    this.ResultViewModel = object;
                }
            })
        },

        updateDataModified: function(){
            this.editData.HoTen = this.editData.Fullname;
            this.editData.Email =   this.editData.Username;
            this.editData.MaNhom = this.editData.SelectedGroups.map(g=>g.Id);

            this.updateData();
        },

        unsetAdmin:function(){
            $.post({
                url:'/'+this.domainUrl+'/unsetAdmin',
                data:{
                    'Id':this.value.Id
                },
                success:(json)=>{//json)=>{
                    alert(`Unset admin ${this.domainName} thành công`);
                    var object = JSON.parse(json);
                    this.$emit('input', object);

                    if(this.value.Id==this.Id)
                        $("#backHome").submit(); 
                }
            })
        },

        setAdmin:function(){
            $.post({
                url:'/'+this.domainUrl+'/setAdmin',
                data:{
                    'Id':this.value.Id
                },
                success:(json)=>{//json)=>{
                    alert(`Set admin ${this.domainName} thành công`);
                    var object = JSON.parse(json);
                    this.$emit('input', object);
                }
            })
        },
    }
})