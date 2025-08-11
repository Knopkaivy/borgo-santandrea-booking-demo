import React, { useState, useEffect } from 'react';


function UnauthorizeView({ children }) {

    const [authorized, setAuthorized] = useState(false);
    const [loading, setLoading] = useState(true);
    let emptyuser = { email: "" };

    const [user, setUser] = useState(emptyuser);


    useEffect(() => {
        // Get the cookie value
        let retryCount = 0; 
        let maxRetries = 10; 
        let delay = 1000;

        function wait(delay) {
            return new Promise((resolve) => setTimeout(resolve, delay));
        }

        async function fetchWithRetry(url, options) {
            try {
                let response = await fetch(url, options);

                if (response.status == 200) {
                    console.log("Authorized");
                    let j = await response.json();
                    setUser({ email: j.email });
                    setAuthorized(true);
                    return response; 
                } else if (response.status == 401) {
                    console.log("Unauthorized");
                    return response; 
                } else {
                    throw new Error("" + response.status);
                }
            } catch (error) {
                retryCount++;
                if (retryCount > maxRetries) {
                    throw error;
                } else {
                    await wait(delay);
                    return fetchWithRetry(url, options);
                }
            }
        }

        fetchWithRetry("/pingauth", {
            method: "GET",
        })
            .catch((error) => {
                console.log(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);


    if (loading) {
        return (
            <>
                <p>Loading...</p>
            </>
        );
    }
    else {
        if (!authorized && !loading) {
            return (
                <>
                    {children}
                </>
            );
        } else {
            return (
                <>

                </>
            )
        }
    }

}

export default UnauthorizeView;