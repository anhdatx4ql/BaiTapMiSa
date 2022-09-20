import moment from 'moment'

/**
 * Author: Phạm Văn Đạt
 * function: format ngày tháng năm
 * created: 20:15 20/08/2022
 */
export function FormatDate(value){
    return moment(String(value)).format('YYYY-MM-DD')
}

/**
 * Author: Phạm Văn Đạt
 * function: format ngày tháng năm post
 * created: 20:20 20/08/2022
 */
export function FormatDatePost(value){
    return moment(String(value)).format('YYYY-MM-DDTHH:mm:ss')
}

/**
 * Author: Phạm Văn Đạt
 * function: Kiểm nga null
 * created: 20:30 20/08/2022
 */
export function IsEmpty(value){
	return value == null // NULL value
        || value == undefined // undefined
        || value == 'undefined' // undefined
        || value.length == 0 // Array is empty
        || value == '00000000-0000-0000-0000-000000000000' // Guid empty
	|| ((value instanceof Date && !isNaN(value.valueOf())) // Validate DateTime value and check min-max value
		&& ((value <= new Date("1753, 01, 01")) // SQL DateTime minimum value
		|| (value >= new Date("9999, 12, 31, 23, 59, 59, 999"))) // SQL DateTime maximum value
	);
}