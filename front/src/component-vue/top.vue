<template>
	<header v-bem>
		<div class="row">
			<div v-bem.logo>logo</div>
			<div v-bem.slogan>slogan</div>
			<div v-bem.user>Привет, {{ username }}</div>
			<nav v-bem.menu>
				<router-link to="/">Главная</router-link>
				<router-link to="/universities">Университеты</router-link>
				<router-link to="/user">Кабинет</router-link>
			</nav>
		</div>
	</header>
</template>

<script>
	export default {
		name: 'top',
		computed: {
			username: function() {
				return this.$store.state.user !== void 0 ? this.$store.state.user : 'noname';
			}
		}
	};
</script>
