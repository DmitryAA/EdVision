<template>
	<div class="b-user">
		<div v-if="logined" class="b-user__start">
			<form @submit="register" class="b-user__register">
				<h2>Регистция</h2>
				<input v-model="username" placeholder="Имя" class="b-user__name"><br>
				<select v-model="rank" class="b-user__rank">
					<option disabled value="">Выберите один из вариантов</option>
					<option>Абитуриент</option>
					<option>Работодатель</option>
					<option>Преподаватель</option>
				</select><br>
				<input type="submit" value="Сделай это" class="b-user__button" :disabled="!username || !rank">
			</form>
			<form @submit="login" class="b-user__login">
				<h2>Вход</h2>
				<input v-model="username" placeholder="Имя" class="b-user__name"><br>
				<input type="submit" value="Пошли" :disabled="!username" class="b-user__button">
			</form>
		</div>
		<div v-else class="b-user__info">
			Добро пожаловать
		</div>
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
