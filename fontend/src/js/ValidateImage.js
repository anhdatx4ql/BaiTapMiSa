const strExtension = ["JPEG", "JPG", "PNG", "GIF", "TIFF" ];

export function TypeImgae(value){
    console.log("vao day")
    if(value){
        let extension = this.image.name.split(".");
        for(let i=0;i<strExtension.length; i++){
            if(extension[1].toUpperCase() == strExtension[i]){
                return true;
            }
        }
    }

    return false;
    

}