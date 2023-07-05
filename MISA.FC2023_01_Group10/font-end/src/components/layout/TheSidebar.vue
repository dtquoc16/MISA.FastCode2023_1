<template>
   <div class="sidebar">
      <div class="sidebar__top">
        <router-link to="/discuss"  class="menu-item">
          <div class="menu-item__icon"><i class="icofont-question-circle"></i></div>
          <div class="menu-item__text">Thảo luận/ Hỏi đáp</div>
        </router-link>
        <router-link to="/reports" class="menu-item">
          <div class="menu-item__icon">
            <i class="icofont-chart-line-alt"></i>
          </div>
          <div class="menu-item__text">Báo cáo</div>
        </router-link>
        <!-- <router-link to="/customers" class="menu-item">
          <div class="menu-item__icon"><i class="icofont-users-alt-3"></i></div>
          <div class="menu-item__text">Khách hàng</div>
        </router-link> -->
        <router-link to="/settings" class="menu-item">
          <div class="menu-item__icon"><i class="icofont-ui-settings"></i></div>
          <div class="menu-item__text">Cài đặt</div>
        </router-link>
      </div>
      <!-- <div class="sidebar__bottom"></div> -->
    </div>
</template>
<style scoped>
.sidebar{
    width: 200px;
    height: calc(100vh - 56px);
    float: left;
    background-color: #041434;
   display: flex;
   flex-direction: column;
}

.sidebar__top{
    flex: 1;
    padding: 20px 12px;
}
.sidebar__bottom{
    height: 44px;
    width: 100%;
    background-color: rgb(79, 23, 57);
}

.menu-item{
    height: 44px;
    display: flex;
    align-items: center;
    column-gap: 12px;
    padding: 0 12px;
    box-sizing: border-box;
    border-radius: 4px;
    cursor: pointer;
    color: #fff;
    text-decoration: none;
}

.menu-item+.menu-item{
    margin-top: 4px;
}
.menu-item:hover{
    background-color: #394c70;
}

.menu-item--active,.router-link-active{
    background-color: #516794;
}

.menu-item__icon{
    width: 24px;
    height: 24px;
    flex: 0 0 24px;
    font-size: 20px;
    color: #fff;
}

</style>