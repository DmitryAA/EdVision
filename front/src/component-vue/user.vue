<template>
	<div v-if="logined">
		<form @submit="register">
			<h2>Регистция</h2>
			<input v-model="username" placeholder="Имя">
			<select v-model="rank">
				<option disabled value="">Выберите один из вариантов</option>
				<option>Абитуриент</option>
				<option>Работодатель</option>
				<option>Преподаватель</option>
			</select>
			<input type="submit" value="Сделай это">
		</form>
		<form @submit="login">
			<h2>Вход</h2>
			<input v-model="username" placeholder="Имя">
			<input type="submit" value="Пошли">
		</form>
	</div>
	<div v-else>
		Добро пожаловать
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'user',
		data() {
			return {
				username: null,
				rank: null,
			};
		},
		computed: {
			logined: function() {
				return this.$store.state.user === void 0;
			}
		},
		methods: {
			register: function() {
				axios
					.post('https://reqres.in/api/users/', {name: this.username, job: this.rank})
					.then(response => {
						this.login();
					});
			},
			login: function() {
				axios
					.post('https://reqres.in/api/login', {
						"email": "eve.holt@reqres.in",
						"password": "cityslicka"
					})
					.then(response => this.$store.commit('login', this.username));
			},
		},
		mounted() {}
	};
</script>
