import axios from 'axios'


// gọi phương thức get từ url
export async function getJSONAsync(url) {

    let json = await axios.get(url);

    return json;
}