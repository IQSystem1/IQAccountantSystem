export interface ProductDTO{
    productId?:number;
    productPrice ?: number;
    productName ?:string;
    productCode ?:string;
    productUnit ?:string;
    productTax ?: number;
    productNote ?:string;
    imageUrl ?:string;
    videoUrl ?:string;
    barcode?:Blob;
    barcodeImage?:string | ArrayBuffer | null;
    productIqCode?:string;
}