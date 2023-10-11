const fetchData = (url) => {   
    return fetch(url)
    .then((response) =>{
        if(!response){
            throw new Error('Network did not respawnd')
        }
        return response.json()
    })
    .catch((error) =>{
        console.log('Error fatching data: ', error)
        throw error;
    })
} 

export default fetchData;
