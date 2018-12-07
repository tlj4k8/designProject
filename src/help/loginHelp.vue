<template>
    <div class="help">
        <div class="images">
        <img src="../employeeManual/employeeManual-01.jpg" class="pic"/>
        </div>
    </div>
</template>
<style scoped>
.help{
    margin-top: 3em;
}
p{
    color: purple;
}
.images{
    display: flex;
    flex-direction: column;
    align-items: center;
}
.pic{
    width: 80vw;
}
@media(max-width: 900px){
    .pic{
        width: 100vw;
    }
    .images{
        width: 100vw;
    }    
}
</style>