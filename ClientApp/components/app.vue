<template>
    <div>
        <h1>Кажется все заработало</h1>
        <p>
            The time is: {{ time }}
        </p>
        The current users of our system are:
        <ul>
            <li v-for="user in users" :key="user.userName">
                {{ user.fullName }} - {{ user.userName }}
            </li>
        </ul>
    </div>
</template>

<script>
    export default {
        name: 'app',
        data() {
            return {
                time: new Date().toString()
            };
        },
        mounted() {
            fetch('/api/users')
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    this.users = data
                })
        }
    };
</script>